using Microsoft.AspNetCore.Mvc;

using TPLOCAL1.Models;

//Subject is find at the root of the project and the logo in the wwwroot/ressources folders of the solution
//--------------------------------------------------------------------------------------
//The controller must imperatively be name with "Controller" at the end !!!
namespace TPLOCAL1.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                //retourn to the Index view (see routing in Program.cs)
                return View();
            else
            {
                //Call different pages, according to the id pass as parameter
                switch (id)
                {   // Lit le fichier XML et envoie la liste des avis à la vue
                    case "OpinionList":
                        string chemin = "XlmFile/DataAvis.xml";
                        OpinionList lecteur = new OpinionList();
                        List<Opinion> avis = lecteur.GetAvis(chemin);
                        return View(id, avis);
                    case "Form":
                        // Affiche la vue Form vide 
                        return View(id, new FormModel());
                    default:
                        //retourn to the Index view (see routing in Program.cs)
                        return View();
                }
            }
        }


        //methode to send datas from form to validation page
        [HttpPost]
        public ActionResult ValidationForm(FormModel model)
        {   // controle, la date doit être antérieure au 01/01/2021
            if (model.StartDate != null && model.StartDate >= new DateTime(2021, 01, 01))
            {
                ModelState.AddModelError("StartDate", "La date doit être antérieure au 01/01/2021");
            }
            // Si tous les contrôles sont OK va à la page de validation, sinon retour au formulaire
            if (ModelState.IsValid)
            {
                return View("ValidationForm", model);
            }
            else
            {
                return View("Form", model);
            } 

        }
    }
}