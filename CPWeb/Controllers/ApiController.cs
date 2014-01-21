using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using WebMatrix.WebData;
using System.Web.Security;
using System.Xml.Serialization;
using System.IO;

namespace CPWeb.Controllers
{
	public class ApiController : Controller
	{
		DataContext db = new DataContext();

		/// <summary>
		/// Registers the user.
		/// </summary>
		/// <returns>The user.</returns>
		/// <param name="username">Username.</param>
		/// <param name="email">Email.</param>
		/// <param name="passwordHash">Password hash.</param>
		[HttpPost]
		public bool RegisterUser(string email, string password, string name)
		{
			// Make sure this only runs on SSL


			// Attempt to register the user
			MembershipCreateStatus createStatus;
			Membership.CreateUser(email, password, email, "question", "answer", true, null, out createStatus);

			if (createStatus == MembershipCreateStatus.Success)
			{
				Student s = new Student ();
				s.name = name;
				s.userName = email;
				db.students.Add (s);
				db.SaveChanges ();
				Roles.AddUserToRole (email, "Student");
				FormsAuthentication.SetAuthCookie (email, false /*					 createPersistentCookie */);
				return true;
			} else
			{
				//ModelState.AddModelError ("", ErrorCodeToString (createStatus));
				return false;
			}
		}

		/// <summary>
		/// Registers the user.
		/// </summary>
		/// <returns>The user.</returns>
		/// <param name="username">Username.</param>
		/// <param name="email">Email.</param>
		/// <param name="passwordHash">Password hash.</param>
		[HttpPost]
		public string Login(string email, string password)
		{
			// make sure this runs on ssl

			if (Membership.ValidateUser (email, password))
			{
				return "true";
			} else
			{
				return "Incorrect username or password";
			}
		}

		/// <summary>
		/// Submits the assessment.
		/// </summary>
		/// <returns>The assessment.</returns>
		/// <param name="assessment">Assessment.</param>
		[HttpPost]
		public string SubmitAssessment(Assessment assessment)
		{
			try
			{
				Student s = db.students.Where (a => a.userName == assessment.Student.userName).Single ();

				assessment.Student = s;

				db.assessments.Add (assessment);

				db.SaveChanges ();

				return "true";
			}
			catch(Exception e)
			{
				return e.Message;
			}
		}

		/// <summary>
		/// Gets the citation database
		/// </summary>
		/// <returns>The assessment.</returns>
		/// <param name="assessment">Assessment.</param>
		public string GetCitations()
		{
			Response.ContentType = "text/xml"; //must be 'text/xml'
			Response.ContentEncoding = System.Text.Encoding.UTF8; //we'd like UTF-8
			db.Configuration.ProxyCreationEnabled = false;
			List<Citation> citations = db.citation.Include("Scene").ToList();

			foreach (Citation c in citations)
			{
				string t = c.scene.name;
			}

			XmlSerializer serializer = new XmlSerializer (typeof(List<Citation>));
			StringWriter textWrite = new StringWriter ();
			serializer.Serialize (textWrite, citations);
			db.Configuration.ProxyCreationEnabled = true;
			return textWrite.ToString ();

		}



	}
}

