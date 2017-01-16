Revisions:

24 August 2016 - Validated the user krchome@hotmail.com (as in pwsafe). For this deleted the user and then recreated by registering 
				 krchome@hotmail.com. Also changed the Application_UserID in Contacts table to match the Id field of the user in AspNetUsers 
				 table. 

21 Sept 2016 - The detailed procedure of creating tables on Azure Db is as follows:

On the VS 2013(ultimate) open up the Server Explorer and expand the left hand side node of your local DB for the project.

On the expanded database objects(Table, Views etc), click on the Tables menu to expand

On the listed Tables, choose and highlight and rt click any table and click => Open Table Definition

This will script the Table with a Tab (middle pane) named T-SQL

Copy the script, name it appropriately and save it for later retrieval for Azure Db.

Repeat steps 3 to 5 to script and save all the tables on your local db 

Now move to expand the Azure cloud database node (probably on SQL server object explorer where you'll find similar nodes to for Table, Views etc.

Expand the Tables node and click "Add New Table"

This will open a similar panes (as before with local db) and the template script for new table written on it

Delete the auto script generated in step 9 and overwrite it with any of the scripts (saved earlier) in step 5

Click "Update" on the Design tab which will generate the update preview script with buttons for Generate Script and Update Database

Click on Update Database, which will create the table and update database (Azure)

Repeat steps 8-12 to create all the tables from saved scripts of local db tables (as in steps 3-5)

28 September 2016 - Sorted out the long stnading issue login failed for user 'krchome' Causes krchome login password was chnaged a couple of weeks back but was showing the old password

 for login 'krchome', although the web.config on remote server for Recnote database was changed. 

 Found out (accidentally while remote debugging) that the settings on RecnoteWebApp as seen by right clicking RecnoteWebApp from server explorer through Azure => Websites => RecnoteWebApp was still displaying 
 
 the old SQL admin password. This was chnaged with the new one and published on Azure. Started functioning correctly
