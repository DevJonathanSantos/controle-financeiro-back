using ControleFinanceiro.Core.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleFinanceiro.Data.Migrations
{                                                                                                                                                   
    /// <inheritdoc />
    public partial class add_gategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
             $@"
                INSERT INTO {nameof(Category)} ({nameof(Category.Name)}) VALUES
                ('Mercado'),
                ('Lanches'),
                ('Roupas/Assesórios'),
                ('Aluguel'),
                ('Outros')
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
