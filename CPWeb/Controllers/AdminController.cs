using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CPWeb.Controllers
{
	[Authorize(Roles="Admin")]
    public class AdminController : Controller
    {
		DataContext db = new DataContext();

        public ActionResult Index()
        {
			List<Student> students = db.students.ToList();

			// eager load information needed for view
			foreach (Student s in students)
			{
				s.assessments.ToList ();
				foreach(Assessment sa in s.assessments)
				{
					int i = sa.scene.id;
				}
			}

			return View (students);
        }

		public ActionResult Students()
		{
			List<Student> students = db.students.ToList();

			List<assessmentVM> assessmentVMs = new List<assessmentVM> ();

			foreach (Student s in students)
			{
				// foreach scene...
				foreach (Scene n in db.scenes.ToList())
				{
					if (s.assessments.Where (v => v.scene == n).Count() < 1)
					{
						continue;
					}
					assessmentVM vm = new assessmentVM ();
					vm.assessment = s.assessments.Where (v => v.scene == n).OrderByDescending (v => v.date).First ();
					vm.firstScore = s.assessments.Where (v => v.scene == n).OrderBy (v => v.date).First ().score;

					int totalScore = 0;
					int count = 0;
					foreach (Assessment f in s.assessments.Where (v => v.scene == n))
					{
						count++;
						totalScore += f.score;
					}

					vm.averageScore = totalScore / count;

					assessmentVMs.Add (vm);

				}
			}

			return View (assessmentVMs);
		}

		public ActionResult Citation()
		{
			List<Citation> citations = db.citation.ToList();


			return View (citations);
		}

		public ActionResult Feedback(int id)
		{
			FeedbackVM feedback = new FeedbackVM();
			feedback.feedback = db.feedback.Where(s => s.Assessment.id == id).ToList ();
			feedback.assessment = db.assessments.Where (a => a.id == id).Single ();
			return View (feedback);
		}

		[HttpPost]
		public ActionResult AddFeedback(FeedbackVM response)
		{
			int id = Int32.Parse (Request.Form ["assessment.id"]);

			// add the response
			Feedback fb = new CPWeb.Feedback ();
			fb.Assessment = db.assessments.Where (a => a.id == id).Single ();
			fb.date = DateTime.Now;
			fb.feedback = Request.Form["response.feedback"];
			fb.user = User.Identity.Name;

			db.feedback.Add (fb);

			db.SaveChanges ();

			return RedirectToAction ("Feedback", new { id = id });
		}

		public ActionResult Details(int id)
		{
			List<AssessmentDetail> assessmentDetails = db.assessmentDetails.Where(s => s.Assessment.id == id).ToList ();
			return View (assessmentDetails);
		}

		/// <summary>
		/// Assessments the specified assessment id (route).
		/// </summary>
		/// <param name="id">Identifier.</param>
		public ActionResult Assessments(int id)
		{
			int sceneId = db.assessments.Where (v => v.id == id).Single ().scene.id;
			int studentId = db.assessments.Where (v => v.id == id).Single ().Student.id;

			// get assessments
			List<Assessment> assessments = db.assessments.Where (v => v.scene.id == sceneId && v.Student.id == studentId).ToList ();

			return View (assessments);

		}


		/// <summary>
		/// Updates the citation.
		/// </summary>
		/// <returns>The citation.</returns>
		/// <param name="id">Identifier.</param>
		public ActionResult UpdateCitation(int id)
		{
			Citation citation = db.citation.Where (v => v.id == id).Single();

			return View (citation);
		}


		/// <summary>
		/// Updates the citation.
		/// </summary>
		/// <returns>The citation.</returns>
		/// <param name="id">Identifier.</param>
		[HttpPost]
		public ActionResult UpdateCitation(Citation citation)
		{
			int id = Int32.Parse(Request.Form["id"]);
			int sceneId = Int32.Parse(Request.Form["scene.id"]);
			Citation cit = db.citation.Where (v => v.id == id).Single ();

			cit.citation = Request.Form["citation"];
			cit.scene = db.scenes.Where (s => s.id == sceneId).Single ();
			cit.title = Request.Form["title"];

			db.SaveChanges ();

			return RedirectToAction("Citation");
		}
    }
}
