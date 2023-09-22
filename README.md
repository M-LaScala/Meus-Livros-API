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

Entitiy frame work

Add-migration
Update-database

Newtonsoft.Json 
para fazer conversão do tipo de data para inserir no banco

[JsonConverter(typeof(CustomDateTimeConverter))]

Ultilizando DTOS -> Data Transfer Object
O modelo de banco de dados não deve ser exposto ao usuario

Como abrir uma conexão entre a API e o banco de dados através do EntityFramework.
Como gerar migrations com .NET 6 e mapear nosso objeto no banco de dados.
O DbContext serve como ponte e para fazer operações no banco.
Como injetar o DbContext em nosso controlador a fim de acessar o banco de dados.
Como salvar as alterações no banco de dados através do método SaveChanges().
DTOs nos ajudam a não deixar nosso modelo de banco de dados exposto.
Como fazer conversões práticas entre diferentes tipos através do AutoMapper.

O Enttity consegue deduzir as Foregin keys atravez dos Modelos e a forma como aplicamos as relações.

A cardinalidade de relacionamentos em bancos de dados se refere à quantidade de ocorrências que estão associadas entre duas entidades em um relacionamento.

Um para Um (1:1):
Cada registro em uma entidade está associado a exatamente um registro na outra entidade, e vice-versa. 
É como um par exclusivo.

Um para Muitos (1:N):
Cada registro em uma entidade pode estar associado a vários registros na outra entidade,
mas cada registro nessa outra entidade está associado a apenas um registro na primeira entidade. 
É como um pai com vários filhos.

Muitos para Muitos (N:N):
Vários registros em uma entidade podem estar associados a vários registros na outra entidade. 
É como uma relação de membros de clube, 
onde cada membro pode estar em vários clubes e cada clube pode ter vários membros.

Exemplo de Json para o PATCH

[
    {
        "op": "replace",
        "path": "/numero",
        "value": "332"
    }
]

Explicar a organização das pastas e o intuito do software.

FromSqlRaw() Permite colocar explicitamente uma consulta ao banco.

Estudar Sobre IIS Express
