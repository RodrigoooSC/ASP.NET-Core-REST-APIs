# Projeto ASP.NET Core REST APIs

Fala pessoal tudo bem? 🖖🏽 Esse projeto foi desenvolvido na formação <a href="https://www.alura.com.br/formacao-dotnet#:~:text=O%20ASP.NET%20Core%20%C3%A9%20uma%20das%20plataformas%20de,se%20aprimorando%20e%2C%20no%20final%2C%20se%20destacar%20profissionalmente%21%21ASP.NET">ASP.NET Core REST APIs</a> da plataforma <a hfer="https://www.alura.com.br/">Alura</a> com a orientação dos professores <a href="https://www.linkedin.com/in/danielartine">Daniel Artine</a> e <a href="https://www.linkedin.com/in/f%C3%A1bio-pimentel-25751b10/">Fábio Pimentel</a>.

## # Sobre o projeto 📚
O projeto consiste no desenvolvimento de APIs REST que simula o gerenciamento de uma plataforma de administração de cinemas. Podendo efetuar o cadastro de cinemas, filmes, gerentes e utilizadores(admistradores e usuários), como também a restrição de acesso a cadastros e consultas por nivel de permissão que foram implantadas no decorrer das aulas.

O projeto possui um serviço de envio de e-mail(<a href="https://accounts.google.com/signin/v2/identifier?service=mail&passive=1209600&osid=1&continue=https%3A%2F%2Fmail.google.com%2Fmail%2Fu%2F0%2F%3Fhl%3Dpt-BR&followup=https%3A%2F%2Fmail.google.com%2Fmail%2Fu%2F0%2F%3Fhl%3Dpt-BR&hl=pt-BR&emr=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin">Gmail</a>) para cadastramento de novos usuários enviando para o mesmo um link com o token de validação de usuário e posteriormente um token de acesso com as permissões predefinidas, lembrando que a aplicação está divida em duas REST APIs(FilmesAPI/UsuarioAPI) que se comunicarão durante a sua execução.

No desenvolvimento do projeto foi utilizado o SKD do .NET(5.0.404) utilizando os seguintes conceitos de programação de REST APIs:

- Operações essenciais com verbos HTTP(Get/Post/Put/Delete);
- Relacionamento de entidades utilizando o EntityFrameworkCore;
- Implementação, autenticação e autorização de usuários utilizando o Identity.

Além dos recursos poderosos do EntityFrameworkCore, a aplicação utiliza outras ferramentas que auxiliam na codificação e na lógica implementada:

- <a href="https://automapper.org/">AutoMapper</a>
- <a href="https://github.com/altmann/FluentResults">FluentResults</a>
- <a href="https://github.com/jstedfast/MailKit">MailKit</a>
- <a href="http://www.mimekit.net/">MimeKit</a>

## # Executando o projeto 🚀

- Clone o repositório:

```bash
git clone https://github.com/RodrigoooSC/ASP.NET-Core-REST-APIs.git
```

- Crie os bancos de dados:

```sql
create database filmesdb;
create database usuariodb;
```

- Configure a ConnectionString no appsettings.json dos projetos conforme suas credenciais:

```json
"FilmeConnection": "server=localhost;database=filmedb;user=user;password=password"
"UsuarioConnection": "server=localhost;database=usuariodbdb;user=user;password=password"
```

- Execute as migrations dos projeto (lembrando que cada projeto possui uma migration diferente):

```bash
dotnet ef database update
```

- Configure uma senha de acesso a aplicativos de terceiros no Gmail:

```link
https://support.google.com/mail/answer/185833?hl=pt-BR
```

- Configure o User Secrets do projeto UsuarioAPI: <a href="https://dotnetcoretutorials.com/2022/04/28/using-user-secrets-configuration-in-net/">Tutorial Secrets</a>

```bash
dotnet user-secrets-init
dotnet user secrets set "EmailSettings:From" "seuemail@gmail.com"
dotnet user secrets set "EmailSettings:SmtpServer" "smtp.gmail.com"
dotnet user secrets set "EmailSettings:Port" "465"
dotnet user secrets set "EmailSettings:Password" "senhageradanogmail"
dotnet user secrets set "adminInfo:Password" "senha_do_admin"

OBS: Por padrão o caminho das secrets são armazenadas neste caminho:
"C:\Users\Fulano\AppData\Roaming\Microsoft\UserSecrets\"
```

- Execute os projeto:

```bash
dotnet run
```

- Endpoints da aplicação, basta fazer o download e importar diretamente no <a href="https://www.postman.com/">Postman</a>:
    - Postman - <a href="https://github.com/RodrigoooSC/ASP.NET-Core-REST-APIs/blob/26ae5018a8aa5c4e49f15304d17a426db08dea3c/Postman%20-%20Json/FilmesAPI.postman_collection.json">FilmesAPI</a>
    - Postman - <a href="https://github.com/RodrigoooSC/ASP.NET-Core-REST-APIs/blob/26ae5018a8aa5c4e49f15304d17a426db08dea3c/Postman%20-%20Json/UsuarioAPI.postman_collection.json">UsuarioAPI</a>

<img src="https://github.com/RodrigoooSC/ASP.NET-Core-REST-APIs/blob/26ae5018a8aa5c4e49f15304d17a426db08dea3c/Postman%20-%20Json/Endpoints.jpeg" />

