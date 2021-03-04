# SQLserver1
SQL Server C# .NET

learning SQL server on VScode with .NET using C# in a console application.

tutorial: https://qawithexperts.com/article/c-sharp/connect-to-sql-server-in-c-example-using-console-application/178

You can also create a connection string in another file like XML, to store connection strings in an external configuration file, create a separate file that contains only the connectionStrings section. Do not include any additional elements, sections, or attributes. This example shows the syntax for an external configuration file.

<connectionStrings>  
  <add name="Name"   
   providerName="System.Data.ProviderName"   
   connectionString="Valid Connection String;" />  
</connectionStrings>  

In the main application configuration file, you use the configSource attribute to specify the fully qualified name and location of the external file. This example refers to an external configuration file named connections.config.

<?xml version='1.0' encoding='utf-8'?>  
<configuration>  
    <connectionStrings configSource="connections.config"/>  
</configuration>  


Properties of the connection string

Property --> Description
Name --> The name of the connection string. Maps to the name attribute.
ProviderName --> The fully qualified provider name. Maps to the providerName attribute.
ConnectionString --> The connection string. Maps to the connectionString attribute.

Here are possible connection string to connect to the database in C#

Standard security

    Server=myServerAddress;Database=myDataBase;User Id=myUsername;
    Password=myPassword;

Trusted connection string in C#

    Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;

Connection to SQL server instance

    Server=myServerName\myInstanceName;Database=myDataBase;User Id=myUsername;
    Password=myPassword;

Connect via an IP address

    connetionString="Data Source=IP_ADDRESS,PORT;
    Network Library=DBMSSOCN;Initial Catalog=DatabaseName;
    User ID=UserName;Password=Password"

LocalDB auto-matic connection string
    
    Server=(localdb)\v11.0;Integrated Security=true;

Attach a database file on connect to a local SQL Server Express instance
    
    Server=.\SQLExpress;AttachDbFilename=C:\MyFolder\MyDataFile.mdf;Database=dbname;
    Trusted_Connection=Yes;

Why is the Database parameter needed? If the named database have already been attached, SQL Server does not reattach it. It uses the attached database as the default for the connection.

Connect to SQL server using windows authentication

    "Server= localhost; Database= databaseName;
    Integrated Security=SSPI;"

Trusted connection from CE device

    connetionString="Data Source=ServerName;
    Initial Catalog=DatabaseName;Integrated Security=SSPI;
    User ID=myDomain\UserName;Password=Password;

That's it, there can be more ways of connection strings but these are widely used one.