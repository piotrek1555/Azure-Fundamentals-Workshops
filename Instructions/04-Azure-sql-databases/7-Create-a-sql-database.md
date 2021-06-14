# 04/1 - Create a SQL database

In this walkthrough, we will create a SQL database in Azure and then query the data in that database.

# Task 1: Create the database

In this task, we will create a SQL database. 

1. Sign in to the Azure portal at [**https://portal.azure.com**](https://portal.azure.com).

2. From the **All services** blade, search for and select **SQL databases**, and then click **+ Create**. 

3. On the **Basics** tab, fill in this information.  

    | Setting            | Value                                                        |
    | ------------------ | ------------------------------------------------------------ |
    | Subscription       | **Use default supplied**                                     |
    | Resource group     | **az-fun-sql-rg**                                            |
    | Database name      | **az-fun-sql-db**                                            |
    | Server             | Select **Create new** (A new sidebar will open on the right) |
    | Server name        | **az-fun-sql-srv-xxxx** (must be unique)                     |
    | Server admin login | **sqluser**                                                  |
    | Password           | **Pa$$w0rd1234**                                             |
    | Location           | **(Europe) West Europe**                                     |
    | Click              | **OK**                                                       |

   ![sql-database-server-create](/assets/sql-database-server-create.PNG)

4. In the **Compute + storage** option, click on **Configure database** link, and select the **Standard** performance tier.
    ![sql-database-server-pricing-tier](/assets/sql-database-server-pricing-tier.PNG)

5. Click **Review + create** and then click **Create** to deploy and provision the resource group, server, and database. It can take approx. 2 to 5 minutes to deploy.


# Task 2: Test the database.

In this task, we will configure the SQL server and run a SQL query. 

1. When the deployment has completed, click **Go to resource** from the deployment blade. Alternatively, from the **All Resources** blade, search and select **Databases**, then **SQL databases** ensure your new database was created. You may need to **Refresh** the page.

    ![sql-database-server-created](/assets/sql-database-server-created.PNG)

2. Click the **az-fun-sql-db** entry representing the SQL database you created. and select the **Query editor (preview)** on the left pane for the `az-fun-sql-db` overview blade.

3. Login as **sqluser** with the password **Pa$$w0rd1234**.

4. You will not be able to login. Read the error closely and make note of the IP address that needs to be allowed through the firewall. 

    ![sql-database-server-login-failed.PNG](/assets/sql-database-server-login-failed.PNG)

5. Back on the **az-fun-sql-db** blade, click **Overview**. 

6. From the az-fun-sql-db **Overview** blade, click **Set server firewall** Located on the top center of the overview screen.
    ![sql-database-server-set-serrver-firewall](/assets/sql-database-server-set-serrver-firewall.PNG)

7. Click **+ Add client IP** (top menu bar) to add the IP address referenced in the error. (it may have autofilled for you - if not paste it into the IP address fields). Be sure to **Save** your changes. 

    ![sql-database-server-set-serrver-firewall-add-client-ip.PNG](/assets/sql-database-server-set-serrver-firewall-add-client-ip.PNG)

8. Return to your SQL database (slide the bottom toggle bar to the left) and click on **Query Editor (Preview)**. Try to login again as **sqluser** with the password **Pa$$w0rd1234**. This time you should succeed. Note that it may take a couple of minutes for the new firewall rule to be deployed. 

9.  Once you log in successfully, the query pane appears. Enter the following queries into the editor pane: 
    - create a Products table code:
        ```SQL
        CREATE TABLE Products (
            Id INT IDENTITY(1,1) NOT NULL,
            ProductName varchar(255),
            Price money
        )
        ```
      Click **Run**, and then review the query results in the **Results** pane. The query should run successfully.

    - insert values into table code (paste it below the previous query, select and hit run):
        ```SQL
        INSERT INTO Products (ProductName, Price)
	    Values
	    ('Product 1', 123.23), 
	    ('Product 2', 500.00), 
	    ('Product 3', 1035.99)

        ```
        ![sql-database-server-queries](/assets/sql-database-server-queries.PNG)
    - query for data code (paste it below the previous query, select and hit run):
        ```SQL
        SELECT * FROM [dbo].[Products]
        ```
        ![sql-database-server-select-query](/assets/sql-database-server-select-query.PNG)

   
**Congratulations!** You have created a SQL database in Azure and successfully queried the data in that database.

**Note**: To avoid additional costs, you can remove this resource group. Search for resource groups, click your resource group, and then click **Delete resource group**. Verify the name of the resource group and then click **Delete**. Monitor the **Notifications** to see how the delete is proceeding.