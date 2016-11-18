using Nancy;
using System.Collections.Generic;
using ContactList;

namespace ContactList
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        var allContacts = Contact.GetAll();
        return View["index.cshtml", allContacts];
      };
      Get["/index"] = _ => {
        var allContacts = Contact.GetAll();
        return View["index.cshtml", allContacts];
      };
      Get["/contacts/new"] = _ => {
        return View["contact_form.cshtml"];
      };
      Post["/contact"] = _ => {
        var newContact = new Contact(Request.Form["new-contact-name"],Request.Form["new-contact-phone"],Request.Form["new-contact-address"]);
        var allContacts = Contact.GetAll();
        return View["/contact_new.cshtml", allContacts];
      };
      Get["/contacts/{id}"] = parameters =>
      {
        var contact = Contact.Find(parameters.id);
        return View["/contact.cshtml", contact];
      };
    }
  }
}
