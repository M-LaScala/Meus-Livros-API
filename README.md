# MeusLivrosAPI

 "API" é a sigla para o termo "Application Programming Interface"

Quando implementamos determinado conjunto de regras arquiteturais, um dos mais difundidos é o REST — Representational State Tranfer. Seguindo esse padrão, sempre saberemos o que vamos receber e o que precisamos enviar nas duas pontas, de modo que a comunicação fica padronizada.

Ao segue o padrão REST, uma API é chamada de API RESTful. Ou seja, REST é o nome do conceito arquitetural e RESTful é quem implementa esse conceito.

Temos os controladores. Como o nome sugere, trata-se de classes responsáveis pelo controle. Elas recebem e respondem às requisições dos usuários que interagem com a API.

A fim de manter a organização do nosso projeto, vamos inserir uma pasta que conterá nossos modelos, que mapearemos do mundo real para o mundo .NET. No gerenciador de soluções, clicaremos com o botão direito sobre "FilmesApi", selecionaremos "Adicionar > Nova Pasta" e a chamaremos de "Models".

BadRequest(); -- STATUS 400
Ok(); -- STATUS 200

[ValidateAntiForgeryToken] é uma medida de segurança utilizada no ASP.NET para proteger contra ataques CSRF (Cross-Site Request Forgery).

O CSRF é um tipo de ataque em que um invasor pode enganar um usuário autenticado a executar ações indesejadas em um aplicativo web, fazendo com que o usuário execute ações não intencionais sem o seu conhecimento.

Quando você coloca o atributo [ValidateAntiForgeryToken] em um método de ação do seu controller, o ASP.NET gera um token de validação exclusivo que é incluído no formulário HTML ou no cabeçalho da requisição POST. Ao receber a requisição no servidor, o ASP.NET compara o token enviado com o token esperado. Se eles não coincidirem, o servidor irá retornar um erro de validação.
