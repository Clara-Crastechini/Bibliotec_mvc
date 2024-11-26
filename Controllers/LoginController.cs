using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bibliotec.Models;
using Bibliotec.Contexts;

namespace Bibliotec.Controllers;

public class LoginController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public LoginController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
    Context context = new Context();


    public IActionResult Index()
    {
        return View();
    }


    // Busca no banco de dados

    [Route("Logar")]
    public IActionResult Logar(IFormCollection form){
        string emailInformado = form["Email"];
        string senhaInformado = form["Senha"];
        return View();
        Usuario usuarioBuscado = context.Usuario.FirstOrDefault(usuario => usuario.Email == emailInformado && usuario.Senha == senhaInformado)!;
    // De outra forma:
    // Criei uma lista de usuarios
        // List<Usuario> listaUsuario = context.Usuario.ToList();
        // foreach (Usuario usuario_ in listaUsuario)
        // {
        //     if(usuario_.Email == emailInformado && usuario_.Senha == senhaInformado){

        //     }else{
        // }
    
        if (usuarioBuscado == null){
            Console.WriteLine($"Dados inválidos");
            return LocalRedirect("~/Login");
        }else{
            Console.WriteLine("Eba batata você entrou");
            HttpContext.Session.SetString("UsuarioID",usuarioBuscado.UsuarioId.ToString());
            HttpContext.Session.SetString("Admin",usuarioBuscado.Admin.ToString());
            return LocalRedirect("~/Login");
        }
        
    }




//     [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//     public IActionResult Error()
//     {
//         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//     }


}
