# ASP.NET Core - Domain Driven Design.
O DDD é uma abordagem de modelagem de software que segue um conjunto de práticas com objetivo de facilitar a implementação de complexas regras / processos de negócios que tratamos como domínio. Domain Driven Design como o nome já diz é sobre design.  
No nosso exemplo, vamos criar um projeto para o cadastro de clientes e se chamara `CadClientes`.

## 01 - Criação do Projeto Solution.
A idéia de criar um projeto do tipo **Blank Solution** é para ter a oportunidade de contruir a arquitura da aplicação com muito mais controle e customização. Assim podemos deixar organizada as `camadas` do nosso desenvolvimento.  
1. Com o visual studio, adicione um projeto do tipo `Blank Solution`. Aproveite para configurar o nome seguido da palavra reservada `Solution`, conforme exemplo: `xyzSolution`. O visual studio vai criar o projeto e será exibido na `Solution Explorer` um projeto em branco, totalmente vazio.

## 02 - Adicionar os Projetos dentro da Solution.
Precisamos adicionar os projetos da nossa aplicação. Geralmente é utilizado as seguintes camadas: `Web, Application, Services, Domain e Infra`. Para facilitar o início dos estudos, vamos abstrair algumas delas e deixar mais simples o nosso exemplo. Para isso, vamos criar apenas as camadas: `Web, Domain e Infra`.
1. Com o botão direito na **Solution**, `Add` -> `New Solution Folder`. Dê o nome `01-Presentation`.
2. Com o botão direito na **Solution**, `Add` -> `New Solution Folder`. Dê o nome `02-Domain`.
3. Com o botão direito na **Solution**, `Add` -> `New Solution Folder`. Dê o nome `03-Infra`.
4. Com o botão direito na pasta **01-Presentation**, `Add` -> `New Project`.  
    4.1 Escolha o **template** `ASP.NET Core Web App (Model-View-Controller)`. Clique em `Next`.  
    4.2 Em **Project name** vamos colocar o nome `CadClientes.Web`. Clique em `Next`.  
    4.3 Em **Target Framework** escolha a versão mais nova.  
    4.4 Em **Authentication Type** deixe `None`.  
    4.5 Clique em `Create`. Será criado o projeto ASP.NET Core MVC.
5. Com o botão direito na pasta **02-Domain**, `Add` -> `New Project`.  
    5.1 Escolha o **template** `Class Library`. Certifique-se de ser para .NET Core. Clique em `Next`.   
    5.2 Em **Project name** vamos colocar o nome `CadClientes.Domain`. Clique em `Next`.  
    5.3 Em **Target Framework** escolha a versão mais nova.  
    5.4 Clique em `Create`. Será criado o projeto.
6. Com o botão direito na pasta **03-Infra**, `Add` -> `New Project`.  
    6.1 Escolha o **template** `Class Library`. Certifique-se de ser para .NET Core. Clique em `Next`.   
    6.2 Em **Project name** vamos colocar o nome `CadClientes.Infra`. Clique em `Next`.  
    6.3 Em **Target Framework** escolha a versão mais nova.  
    6.4 Clique em `Create`. Será criado o projeto.  

Nesse memento, o resultado final deverá resultar em um projeto em cada **Solution Folder**. Teremos então a seguinte árvore de pastas e projetos.
```
01-Presentation
  CadClientes.Web
02-Doamin
  CadClientes.Domain
03-Infra
  CadClientes.Infra
```

## 03 - Organizar os projetos criados.
1. Nos projetos `CadClientes.Domain` e `CadClientes.Infra`, remova o classe Class1.cs
2. No projeto `CadClientes.Domain`, criar a estrutura de pastas conforme exemplo a seguir:
- Entities  
- Interfaces  
  * Repositories (Essa pasta fica dentro da pasta Interfaces)
3. No projeto `CadClientes.Infra`, criar a estrutura de pastas conforme exemplo a seguir:
- Context
- EntityConfig
- Repositories


4. No projeto `CadClientes.Infra`, adicionar a referência para o projeto `CadClientes.Domain`.
5. No projeto `CadClientes.Web`, adicionar a referência para o projetos `CadClientes.Domain` e `CadClientes.Infra`.

## 04 - Configurar o Projeto de Domínio
Cada projeto possui a sua complexidade de classes, no nosso caso é um projeto simples com apenas uma claase. Mas poderia ser um projeto extenso com diversos relacionamentos. Nesse caso, basta criar a quantidade de classes apropriada para o seu projeto, bem como a quantidade de interfaces de repositórios.
1. Dentro da pasta `Entities`, crie a classe `Cliente.cs`.
```
public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public int Idade { get; set; }
    public string Telefone { get; set; }
}
```
2. Dentro da pasta `Interfaces/Repositories`, crie a interface genérica `IRepositoryBase.cs`.
```
public interface IRepositoryBase<TEntity> where TEntity : class
{
    void Create(TEntity obj);
    IEnumerable<TEntity> GetAll();
    TEntity GetById(int id);
    void Update(TEntity obj);
    void Remove(TEntity obj);
}
```
3. Dentro da pasta `Interfaces/Repositories`, crie a interface especializada `IClienteRepository.cs`.
```
public interface IClienteRepository: IRepositoryBase<Cliente>
{
}
```

## 05 - Configurar o Projeto Infra
1. Utilizando o `Package Manager Console`, instale os packages do `Entity Framework Core`. Instalar um cada vez.  
   * É necessário deixar o projeto `CadClientes.Infra`  como `Startup Project`.   
   * No `Package Manager Console` aponte para o projeto `CadClientes.Infra`.
```
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.Design
Install-Package Microsoft.EntityFrameworkCore.Relational
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Microsoft.EntityFrameworkCore.Proxies
```
2. Dentro da pasta `EntityConfig`, criar o arquivo `ClienteConfig.cs`.
```
public class ClienteConfig : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome).HasMaxLength(50);
        builder.Property(x => x.CPF).HasMaxLength(11);
        builder.Property(x => x.Telefone).HasMaxLength(15);
    }
}
```