# Products.Api

This is the projects and libraries structure

![image](https://github.com/juandave25/Products.Api/assets/38296518/638ad96b-d049-4345-a69f-e71484b79e30)

Folder Structure

![image](https://github.com/juandave25/Products.Api/assets/38296518/b19b4ba8-7760-49aa-960b-c605e57215a6)

Before executing this solution, you need to follow these steps:

1. Change ConnectionString in the <code>appsettings.json</code> and <code>Context.cs</code> file with your connection string

2. Execute the next commands in your Nuget package console pointing to Products.Api.Data Class Library :  
  <code>Update-database InitialMigrationDB</code>

3. Open your visual studio and select default <code>Products.Api</code> as a launch project

4. Open the Postman folder and import collection from Postman execute the <code>authlogin</code> endpoint to get a bearer token and start to test every endpoint. 

   PD: <code>{username: test - password: password}</code> for JSON body in authenticate endpoint. Enpoints to create, update, and delete products need a bearer token, you can get products without authentication and authorization.

6. If you want to use swagger you can run this URL :
   <code>https://localhost:5001/swagger</code>
