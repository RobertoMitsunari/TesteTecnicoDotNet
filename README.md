
# Teste Técnico – Desenvolvedor .NET. 

API em .NET com métodos CRUD para as entidades Cliente, Financimento e Parcela
Também é possivel simular Creditos em 5 categorias:

```
• Crédito Direto Taxa de 2%
• Crédito Consignado Taxa de 1% 
• Crédito Pessoa Jurídica Taxa de 5% 
• Crédito Pessoa Física Taxa de 3% 
• Crédito Imobiliário Taxa de 9% 
```

A forma do calculo do Juros pode ser alterada dentro do código.




## Instalação

Abra o projeto pelo Visual Studio ou outro editor.

Alterar a connection string dentro do appsetting.json para o seu SQL Server:

```SQL
  "DefaultConnection": "Server=localhost,1433;Database=Credito;User Id=sa; Password=Roberto@123;TrustServerCertificate=True"
```

Após isso rode o Update-Database dentro do Package Manager Console
```bash
  update-database
```
Inicie o projeto.