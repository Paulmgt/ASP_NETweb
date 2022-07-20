using AspCorePremeiereApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspCorePremeiereApp.Controllers
{
    public class TestController : Controller
    {

        //une action qui retourne une Vue

        public IActionResult  MaVue()
        {

            return View();
        }
        // cas 2

        public IActionResult MaVue2()
        {

            return View("MaVue");
        }
        public IActionResult MaVue3()
        {

            return View("Toto");
        }

        // Une action qui retourne un string

        public string MaString()
        {

            return "Hello, depuis ma page web!";
        }

        // retourner du Json, un objet 

        public IActionResult GetJson()
        {

            var data = new  {  Nom="Vadel", Prenom="Cheikh"};
            // data est un objet de type anonyme 

            return Json(data);

        }
        // Avec un Model ? une voiture
        public IActionResult GetVoiture()
        {
          //  var v = new  { Id = 1, Nom="208", Marque="Peugeot"}; //objet anonyme -- JSON
            Voiture  v = new Voiture() { Id = 1, Nom="208", Marque="Peugeot"};

            // 
            return View("Voiture", v);  // on envoie un objet à la vue GETVoiture
        }

        public IActionResult GetVoitures()
        {
            // Sous format JSON --pas de vue 
           if (voitures.Count==0) MesVoitureGenerees();
            return Json(voitures);

        }
      private static List<Voiture> voitures = new List<Voiture>();
        private void MesVoitureGenerees()
        {
           // List<Voiture> voitures = new List<Voiture>();
            Random random = new Random();
            int num;
            for (int i = 0; i < 10; i++)
            {
                num = random.Next(0, 1000);
                Voiture voiture = new Voiture() { 
                 Id = num,
                 Nom = "nom "+num,
                 Marque="Marque  "+num
                };
                 voitures.Add(voiture);
            }
           // return voitures;
        }

        // Liste de voitures dans une Vue?

        public IActionResult MesVoitures()
        {
            // qui retourne une liste de voitures
            if (voitures.Count == 0) MesVoitureGenerees();
            return View ("Voitures", voitures);
            // créer la Vue qui retourne affiche la liste de voitures
        }
        // Saisie = get pour envoyer un formulaire + post pour le récupérer avec les datas

        [HttpGet]
        public IActionResult Saisie()
        {
            return View();
        }

 
        [HttpPost]
        public IActionResult Saisie(Voiture v)
        {
            voitures.Add(v);
            return RedirectToAction(nameof(MesVoitures));
        }

        [HttpPost]
        public IActionResult Modif(int id)
        {
            // rechercher la voiture à modifier
            Voiture voitureAModifier = voitures.FirstOrDefault(x => x.Id == id);
            // si la voiture à modifier n'existe pas on retourne la liste  actualisée
            if (voitureAModifier == null) return RedirectToAction(nameof(MesVoitures)); 
            // si on trouve la voiture à modifier alors on doit lui retourner cette voiture
            // dans un formulaire afin qu'il puisse faire ses modif

            return Json(new { Suppresion = "OK"});
        }

        public IActionResult Supprimer2(int id)
        {
            Voiture voitureAModifier = voitures.FirstOrDefault(x => x.Id == id);
            return View(VoitureASupprimer);
        }

        [HttpPost]
        public IActionResult Supprimer2(Voiture voiture)
        {
            Voiture voitureAModifier = voitures.FirstOrDefault(x => x.Id == voiture.Id);
            voitures.Remove(voitureAModifier);

            return RedirectToAction(nameof(MesVoitures));
        }
    }
}
