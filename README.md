# Chess Console
A - Gestor Pessoa API
> A aplication for people

## Resumo
- Responsável pelo cadastro da pessoa e relação de dividas. 
- Sistema com banco de dados relacional. 
- Autenticação JWT 
- Ao criar/alterar cliente, notifica os interessados ([Sistema B](https://github.com/IVictorinoI/BGestorRendaBem/) e [Sistema C](https://github.com/IVictorinoI/CExtrato/) com RabbitMQ) 
- Sistema mais robusto com Domain, Application e Api, usando validadores, Dtos e Views, Interfaces, etc. 
- Sistema não expoe o seu domínio, todas as informações são trafegadas por Dtos e Views e passsam por validadores para manter a consistencia das informações.
- A API possui swagger.


## Tabelas
- Cliente (Id, Nome, Cpf, DataNascimento, Endereco, Profissao, RendaMensal, Ativo) **GET, POST, PUT, DELETE (Inativar)** (Ao salvar chama RabbitMQ e [Sistema B](https://github.com/IVictorinoI/BGestorRendaBem/) e [Sistema C](https://github.com/IVictorinoI/CExtrato/) consomem) 
- Divida (Id, IdCliente, Titulo, Vencimento, Valor, ValorPago, Saldo, Status{Aberta, Cancelada, Paga}, PagouAtrasado{bool}) **GET, POST, DELETE(canc)** 
- DividaPagamento (Id, IdDivida, Data, Valor, Status) **GET, POST, DELETE(canc)** 

## Customer
Cadastro de clientes, não permite clientes com mesmo CPF, ao salvar integra com os sistemas [Sistema B](https://github.com/IVictorinoI/BGestorRendaBem/) e [Sistema C](https://github.com/IVictorinoI/CExtrato/) com RabbitMQ


## Debt
Histórico de débitos ativos e pagos. Registra informações se foi pago em atraso ou não.

## DebtPaiment
Cada pagamento atualiza o Debito, informando o valor restante e se foi pago em atraso.

## Login
Como todas as request são protegidas por autenticação JWT é necessário se cadastrar no sistema e depois se autenticar.
A request ExternalAuthentication é para que outros sistemas consigam utilizar sem precisar ter o Login e Senha, basta gerar um ClientId e um ClientSecret de integração.


Autor [Victor Matheus Mendes](https://github.com/IVictorinoI/)