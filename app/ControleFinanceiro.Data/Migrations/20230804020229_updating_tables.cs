using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleFinanceiro.Data.Migrations
{
    /// <inheritdoc />
    public partial class updating_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Categoria_CategoriaId",
                table: "Expense");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "ExpenseParcela");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Expense");

            migrationBuilder.RenameColumn(
                name: "TipoPagamento",
                table: "Expense",
                newName: "TypePayment");

            migrationBuilder.RenameColumn(
                name: "QTDParcelas",
                table: "Expense",
                newName: "QuantityParcels");

            migrationBuilder.RenameColumn(
                name: "DataCadastro",
                table: "Expense",
                newName: "DateRegistered");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "Expense",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_CategoriaId",
                table: "Expense",
                newName: "IX_Expense_CategoryId");

            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                table: "Expense",
                type: "DECIMAL(12,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parcel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateParcel = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<decimal>(type: "DECIMAL(12,2)", nullable: false),
                    ExpenseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcel_Expense_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expense",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_ExpenseId",
                table: "Parcel",
                column: "ExpenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Category_CategoryId",
                table: "Expense",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Category_CategoryId",
                table: "Expense");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Parcel");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Expense");

            migrationBuilder.RenameColumn(
                name: "TypePayment",
                table: "Expense",
                newName: "TipoPagamento");

            migrationBuilder.RenameColumn(
                name: "QuantityParcels",
                table: "Expense",
                newName: "QTDParcelas");

            migrationBuilder.RenameColumn(
                name: "DateRegistered",
                table: "Expense",
                newName: "DataCadastro");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Expense",
                newName: "CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_CategoryId",
                table: "Expense",
                newName: "IX_Expense_CategoriaId");

            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "Expense",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseParcela",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    DataParcela = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseParcela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseParcela_Expense_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expense",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseParcela_ExpenseId",
                table: "ExpenseParcela",
                column: "ExpenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Categoria_CategoriaId",
                table: "Expense",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
