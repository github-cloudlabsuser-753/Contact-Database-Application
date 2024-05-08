using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;

namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>(){
                new User()
        {
            Id = 1,
                Name = "Saloni",
                Email = "saloni@manulife.ca"
                },

    };

    // GET: User
    public ActionResult Index()
    {
            // return userlist to the view
            return View(userlist);
        }

    // GET: User/Details/5
    /*public ActionResult Details(int id)
    {
        // Implement the details method here
    }*/

    // GET: User/Create
    public ActionResult Create()
    {
            //create new user
            return View();
        }

    // POST: User/Create
    [HttpPost]
    public ActionResult Create(User user)
    {
            // Implement the Create method (POST) here
            if (ModelState.IsValid)
            {
                userlist.Add(user);
                return RedirectToAction("Index");
            }
            // If the model state is not valid, return the Create view to display validation errors.
            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // This method is responsible for displaying the view to edit an existing user with the specified ID.
            User user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            // It retrieves the user from the userlist based on the provided ID and
            // passes it to the Edit view.
            return View(user);

        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            // This method is responsible for handling the HTTP POST request to update an existing user with the specified ID.
            id = user.Id;
            // get user from userlist
            User userToUpdate = userlist.FirstOrDefault(u => u.Id == id);
            // If no user is found with the provided ID, it returns a HttpNotFoundResult.
            if (userToUpdate == null)
            {
                return HttpNotFound();
            }
            // It updates the user properties with the values from the model binder.
            
            userToUpdate.Name = user.Name;
            userToUpdate.Email = user.Email;
            // remove the existing user from userlist
            userlist.Remove(userToUpdate);
            // add userToUpdate to userlist
            userlist.Add(userToUpdate);

            // If successful, it redirects to the Index action to display the updated list of users.
            return RedirectToAction("Index");

            // If an error occurs during the process, it returns the Edit view to display any validation errors
            
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            // Implement the Delete method here
            User user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);

        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // find the user in userlist
            User user = userlist.FirstOrDefault(u => u.Id == id);
            //delete the user from userlist
            userlist.Remove(user);
            // return to index
            return RedirectToAction("Index");
        }
    }
}