# Aplicação Asp Net Core (Cadastro de Usuários) <h1>

#### Solução Composta por duas aplicações que simulam dois canais diferentes.

## Documentação de abertura e compilação da aplicação

### Requisitos:

1 - Uma máquina com Windows, macOS ou Linux.
<br>
2 - Visual Studio 2022(onde a aplicação foi desenvolvida). - https://visualstudio.microsoft.com/pt-br/downloads/
<br>
3 -.NET Core SDK 6.0 ou superior. - Link Sdk 6.0: https://download.visualstudio.microsoft.com/download/pr/9b3cbb1c-3368-4a5a-a899-b1c6ec5c0c3e/cb4de75dd805113129a7f903d125e4b0/dotnet-sdk-6.0.415-win-x64.exe

### Montando a Solução com dois canais (Api Web e aplicação Web)
1 - Abra o arquivo .sln - arquivo se encontra em (\API_C-sharp\API_ASP_NET).
<br>
2 - Abre as propriedades da solução, marque a opção "Vários projetos de inicialização" e selecione - API_ASP_NET e APP.CadastroUsuario 
<br>
Ex:
<br>
![Img_prop](https://github.com/fbatalha7/API_C-sharp/blob/main/Img_Propriedades_proj_Bemol.png)
<br>
2 - Compile e execute

## Passoa Alternativos

#### Se a compilação na sua maquina retorna uma Conexão diferente de "https://localhost:7047":
Altere as rotas de "ConnectionStrings" no arquivo "appsettings.json" em API_C-sharp\API_ASP_NET.
<br>
![Img_prop](https://github.com/fbatalha7/API_C-sharp/blob/main/Img_App_Json.png)
<br>

###Informações Adicionais
- O projeto foi feito com dados de uma lista estatica que simula um banco de dados
- Esta solução contem dois canais - Aplicação Web AspNetCore e Web Api (aplicação projetada para o cenário em que amabas aplicações estejam no mesmo servidor utilizando portas diferentes.).
- Pacotes Nuggets Externas Usados no projeto - NewtonSoft.Json(App.Domain) e FluentValidator(APi.Services).
