using Nancy;
using System.Collections.Generic;
using ContactList;
using System;

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
      Post["/contacts/clear"] = _ =>
      {
        var allContacts = Contact.GetAll();
        allContacts.Clear();
        return View["contacts_clear.cshtml"];
      };
      // Post["/contact/clear/{id}"] = parameters =>
      // {
      //   System.Console.WriteLine("made it");
      //   var contact = Contact.Find(parameters.id);
      //   var allContacts = Contact.GetAll();
      //   allContacts.Remove(contact);
      //   return View["contact_clear.cshtml"];
      // };
    }
  }
}
