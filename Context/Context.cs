using Bibliotec.Models;
using Microsoft.EntityFrameworkCore;

namespace Bibliotec.Contexts
{

    // Classes que terá as informações do banco de dados
    public class Context : DbContext
    {
        // Criar um metodo construtor 

        public Context(){

        }

        public Context(DbContextOptions<Context> options) : base(options){
            
        }
        //  OnConfiguring -> possui a configuração da conexão do banco de dados 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            // colocar as informacoes do banco

            //  as configuracoes existem?

            if (!optionsBuilder.IsConfigured){
                // string de conexao do banco de dados:
                // Data Source -> Nome do servidor do banco de dados.
                // Initial Catalog -> Nome do banco de dados.
                // User id e Password = Informacoes de acesso ao servidor do banco de dados.
                // Integrated Security=true e TrustServerCertificate = linhas excepcionais para determinar 
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-D69BRM9\\SQLEXPRESS02; Initial Catalog = Bibliotec_mvc; User Id=sa; Password=123; Integrated Security=true; TrustServerCertificate = true");
            }
        }
        
        //  As referências das nossas tabelas no banco de dados:
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<LivroCategoria> LivroCategoria { get; set; }
        public DbSet<LivroReserva> LivroReserva { get; set; }

        
    }
}