# Exercício de Injeção de dependência 
=======================================================

Exercício do curso - Dominando Injeção de Dependência, do site https://balta.io/

Repositório do curso: https://github.com/balta-io/2813

===================================================================================
## Questões citadas no curso sobre injeção de dependência 

##### 1. Qual a diferença entre AddTransient, AddScoped e AddSigleton?

* AddSingleton quando temos uma instância para a aplicação toda.
* AddScoped quando temos uma instancia por requisição
* AddTransient a instancia e renovada toda vez que ela é chamada.
  
##### 2. Qual a finalidade do atributo FromServices?
Caso o service só seja usado naquela chamada, invés de passar pelo construtor, podemos passa-los por parâmetro no método até o .NET 6 era necessário usar o atributo FromService para identificar a interface, as novas versões o .NET já identifica que é uma interface.
#####  3. Podemos resolver dependências fora dos controladores? (Quais situações e melhor usar fora dos controladores)
* HTTPContext
* Program.cs
* FromService direto no método do Controler
* Construtor no Controler
  
##### 4. De forma resumida, você consegue me dizer o que é injeção de dependência? 
É uma classe ser injetada na classe que depende dela para funcionar.
##### 5. O que é inversão de controle?
E uma classe que externaliza responsabilidades. Passa a responsabilidade para um serviço
##### 6. O que é Inversão de Dependência?
E um principio onde se depende de abstração, é não de implementação
##### 7. Qual a relação entre injeção de dependência, inversão de controle e inversão de dependência?
A injeção de dependência é um Design Pattern, que implementa inversão de controle e o Dependency Inversion Principal.
