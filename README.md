# MeusLivrosAPI

 "API" é a sigla para o termo "Application Programming Interface"

Quando implementamos determinado conjunto de regras arquiteturais, um dos mais difundidos é o REST — Representational State Tranfer. Seguindo esse padrão, sempre saberemos o que vamos receber e o que precisamos enviar nas duas pontas, de modo que a comunicação fica padronizada.

Ao segue o padrão REST, uma API é chamada de API RESTful. Ou seja, REST é o nome do conceito arquitetural e RESTful é quem implementa esse conceito.

Temos os controladores. Como o nome sugere, trata-se de classes responsáveis pelo controle. Elas recebem e respondem às requisições dos usuários que interagem com a API.

A fim de manter a organização do nosso projeto, vamos inserir uma pasta que conterá nossos modelos, que mapearemos do mundo real para o mundo .NET. No gerenciador de soluções, clicaremos com o botão direito sobre "FilmesApi", selecionaremos "Adicionar > Nova Pasta" e a chamaremos de "Models".

BadRequest(); -- STATUS 400
Ok(); -- STATUS 200
CreatedAtAction(); -- STATUS 201
NotFound(); -- STATUS 404

[ValidateAntiForgeryToken] é uma medida de segurança utilizada no ASP.NET para proteger contra ataques CSRF (Cross-Site Request Forgery).

O CSRF é um tipo de ataque em que um invasor pode enganar um usuário autenticado a executar ações indesejadas em um aplicativo web, fazendo com que o usuário execute ações não intencionais sem o seu conhecimento.

Quando você coloca o atributo [ValidateAntiForgeryToken] em um método de ação do seu controller, o ASP.NET gera um token de validação exclusivo que é incluído no formulário HTML ou no cabeçalho da requisição POST. Ao receber a requisição no servidor, o ASP.NET compara o token enviado com o token esperado. Se eles não coincidirem, o servidor irá retornar um erro de validação.

Data Annotations As Data Annotations são uma forma de adicionar metadados e regras de validação aos modelos de dados em ASP.NET

[Required]: Indica que uma propriedade é obrigatória, ou seja, não pode ser nula ou vazia.
[StringLength]: Define o tamanho máximo e mínimo de uma string.
[Range]: Define um intervalo de valores permitidos para uma propriedade numérica.
[EmailAddress]: Valida se uma propriedade é um endereço de e-mail válido.
[RegularExpression]: Aplica uma expressão regular para validar o formato de uma propriedade.
[Compare]: Compara o valor de uma propriedade com o valor de outra propriedade em um modelo.

Paginação
A paginação nos permite retornar trechos da nossa lista, em lugar de sua totalidade. Para aplicar esse conceito no .NET, utilizaremos os métodos .Skip() e Take().

O método Skip() indica quantos elementos da lista pular, enquanto o Take() define quantos serão selecionados. Vamos conferir na prática como eles funcionam, no método RecuperaFilmes():
