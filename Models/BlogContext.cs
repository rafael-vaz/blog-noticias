using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

/*

[COMANDOS DOTNET UTILIZADOS]

dotnet tool install --global dotnet-ef (instalando a ferramenta dotnet-ef como uma ferramenta global)

dotnet add package Pomelo.EntityFrameworkCore.MySql --version 2.2.6 (instalando o pacote pomelo - entity framework)

dotnet add package Microsoft.EntityFrameworkCore.Design --version 2.2.6 (instalando o pacote entity framework design)

dotnet ef migrations add CreateDatabase (realizando a criação do banco de dados com o migrations)

dotnet ef database update (implementação e atualização final do banco de dados)

dotnet ef migrations add ChangeVarchar(atualiza as novas mudanças realizadas nas classes do banco)

dotnet ef migrations remove (remove as ultimas mudanças realizadas no banco através do migrations)

*/

namespace Blog.Models
{
    public class BlogContext : DbContext
    {
        
          protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          {
              optionsBuilder.UseMySql("Server=localhost;DataBase=Blog;Uid=root;Pwd=;");
          }

          public DbSet<Post> Posts { get; set; }
          public DbSet<Comentario> Comentarios { get; set; }
    }
}