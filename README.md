# Agenda Online

AgendaOnline é um sistema de agenda de contatos pessoal desenvolvido como trabalho de conclusão do curso de **Bacharelado em Análise e Desenvolvimento de Sistemas**, finalizado em **dezembro de 2023**.

Este projeto foi construído utilizando tecnologias modernas da stack Microsoft e segue a arquitetura MVC, com suporte completo para registro de usuários, autenticação e recuperação de senha via e-mail.

---

## ✨ Funcionalidades

- Cadastro de usuários com verificação de e-mail
- Login com autenticação segura
- Recuperação de senha via e-mail
- Cadastro, edição, listagem e exclusão de contatos pessoais
- Interface web responsiva com ASP.NET Razor Pages

---

## 🧰 Tecnologias Utilizadas

- **Front-end**: ASP.NET Razor Pages
- **Back-end**: .NET 8 (C#)
- **Banco de Dados**: Microsoft SQL Server 2022
- **Arquitetura**: MVC (Model-View-Controller)

---

## 🔧 Requisitos de Instalação

- [.NET SDK 8](https://dotnet.microsoft.com/en-us/download)
- [SQL Server 2022](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/) com suporte a .NET e desenvolvimento web
- Conta de e-mail válida (mock ou real) para funcionalidades de registro e recuperação de senha

---

## 📦 Configuração do Projeto

1. **Clone o repositório:**
bash
git clone https://github.com/thatsallaboutleo/AgendaOnline.git
cd AgendaOnline

2. **Configure a string de conexão no appsettings.json:**
```
"ConnectionStrings": {
  "DefaultConnection": "Server=SEU_SERVIDOR;Database=agendaOnlineDB;User Id=USUARIO;Password=SENHA;"
}
```

3. **Configure os dados de envio de e-mail (mock ou real):**
```
"EmailSettings": {
  "SmtpServer": "smtp.exemplo.com",
  "Port": 587,
  "Username": "seuemail@exemplo.com",
  "Password": "suaSenha"
}
```

4. **Crie e atualize o banco de dados:**
```dotnet ef database update```

5. **Execute o projeto:**
```dotnet run```

## 👨‍🎓 Sobre o Autor
- Leonardo Brochetti
- Projeto final do curso de Bacharelado em Análise e Desenvolvimento de Sistemas
- Conclusão: Dezembro/2023

## 📃 Licença
- Este projeto é de uso acadêmico. Caso queira utilizá-lo, sinta-se livre para estudar, adaptar ou expandir com os devidos créditos.
