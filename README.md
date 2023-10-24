# Aplicação Asp Net Core (Cadastro de Usuários) <h1>

###Informações Adicionais
- O projeto foi feito com dados de uma lista estatica que simula um banco de dados

## Documentação de abertura e compilação da aplicação

### Requisitos:

1 - Uma máquina com Windows, macOS ou Linux.
<br>
2 - Visual Studio 2022(onde a aplicação foi desenvolvida) ou Visual Studio Code. - https://visualstudio.microsoft.com/pt-br/downloads/
<br>
3 -.NET Core SDK 6.0 ou superior. - https://dotnet.microsoft.com/pt-br/download/dotnet/6.0

### Montando a Solução com dois canais (Api Web e aplicação Web)
1 - Abra o arquivo .sln - arquivo se encontra em (\API_C-sharp\API_ASP_NET).
<br>
2 - Abre as propriedades da solução, marque a opção "Vários projetos de inicialização" e selecione - API_ASP_NET e APP.CadastroUsuario 
<br>
Ex:
<br>
![Img_prop](https://github.com/fbatalha7/API_C-sharp/blob/main/Img_Propriedades_proj_Bemol.png)
<br>
2 - Compile e execute a aplicação

## Passoa Alternativos

#### Se a compilação na sua maquina retorna uma Conexão diferente de "https://localhost:7047":
Altere as rotas de "ConnectionStrings" no arquivo "appsettings.json" em API_C-sharp\API_ASP_NET.
<br>
![Img_prop](https://github.com/fbatalha7/API_C-sharp/blob/main/Img_App_Json.png)
<br>

