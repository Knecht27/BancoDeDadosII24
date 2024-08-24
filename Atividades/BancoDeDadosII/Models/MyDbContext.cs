using Microsoft.EntityFrameworkCore;

namespace BancoDeDadosII.Models
{
    // A classe de contexto do banco de dados
    // ou DbContext é responsavel por mapear as classes que serão atreladas
    //ás tabelas do banco de dados.
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {

        }

        // nesta sessão especificamos as 
        // classes do Model que serão 
        // espelhadas em tabelas do BD

        public DbSet <Pessoa> Pessoas {  get; set; } 


    }
}
