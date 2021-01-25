# True Crime Repo
The go-to resource for all true crime fanatics and arm chair sleuths to find the best and up-to-date media around their favorite true crimes.

The user can view, add, edit, and delete true crimes, podcasts, tv shows, and books.

True Crime Repo is a .NET Framework MVC 5 Web Application using n-tier architecture.

##	Files
#### Data
- Crimes [FK]
- Podcasts (ICollection)
- TV Shows (ICollection)
- Books (ICollection)
- Perpetrators (not active in the view)
- Identity Models

Models
- Book
	- Book List Item
	- Book Create
	- Book Details
	- Book Edit
	- Book Delete
- Crime
	- Crime List Item
	- Crime Create
	- Crime Details
	- Crime Edit
	- Crime Delete
- Perpetrator
	- Perpetrator List Item
	- Perpetrator Create
	- Perpetrator Details
	- Perpetrator Edit
	- Perpetrator Delete
- Podcast
	- Podcast List Item
	- Podcast Create
	- Podcast Details
	- Podcast Edit
	- Podcast Delete
- TV Show
	- TV Show List Item
	- TV Show Create
	- TV Show Details
	- TV Show Edit
	- TV Show Delete

Services 

 - CrimeServices
 - PodcastServices 
 - PerpetratorServices 
 - TVShowServices
 - BookServices

Controllers

 - CrimeController 
 - PerpetratorController 
 - PodcastController
   TVShowController 
   BookController

Views .csthml
 - Home 
	 - About
	 - Index
 - Crime
	 - Index
	 - Create
	 - Edit
	 - Delete 
 - Podcast
	 - Index
	 - Create
	 - Edit
	 - Delete  
 - TV Show 
	 - Index
	 - Create
	 - Edit
	 - Delete 
 - Book 
	 - Index
	 - Create
	 - Edit
	 - Delete 

## Resources utilized

 - https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/
 - https://bootswatch.com/3/
 - https://www.tutorialsteacher.com/mvc/asp.net-mvc-tutorials
 - https://getbootstrap.com/docs/3.3/components/
 - https://fontawesome.com
 - https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/sorting-filtering-and-paging-with-the-entity-framework-in-an-asp-net-mvc-application
 - https://stackoverflow.com/questions/40478711/implementing-a-simple-search-function-in-asp-net-mvc

## How to utilize
Each user must create an account to have access to the site.

User will click the register button and create an account.

Once registered, the user can view the crimes index, podcasts index, tv shows index, and books index.

Within the crime index, the user can do the following:

 - Add a new true crime Edit an existing true crime 
 - View the full details of a true crime which includes the podcasts, tv shows, and books for that crime. 
 - Delete an existing true crime

Within the podcast, tv show, and book index, the user can do the following:

 - Add a podcast, tv show, and book to a true crime.
 - Edit an existing podcast, tv show, and book.
 - View all details of an existing podcast, tv show, and book.
 - Delete an existing podcast, tv show, and book.


## Upcoming features
- Pagination
- Search function
- Preventing duplicate entries
- Social sharing
- Ability to add images
