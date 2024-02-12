# Blazor-Shared-UI
A shared UI between Blazor Web and Hybrid which is not just components but full web pages and other functionality

This is a template project with some example pages to help get you started on your next hybrid Blazor Web and Application Project. This is designed to use both frameworks at the same time pulling from one source, that does mean you will have to modify the base `Web` and `Deskto`p projects to be aware of certain files in the `Base` project.

## Pages
These are the core of what this app is meant for. Giving you the ability to share pages across the two apps. Simply add a new page in the `Base` project under the pages folder. Make sure you includes the `@pages` at the top of the .razor file and it should work right away in this template project.

## Components
Another core part of the project, this allows for smaller html components to be used in multiple places or simplify code. They live in the `Base` project under the components folder.

## Singletons
Singletons restricts the instantiation of a class to a singular instance. If you want to create more singletons to keep track of global variables or states, I have created the examples `Names` to showcase how you would do so. 
1. Create a new class in the `Base` project under the Singleton folder
2. In the `Web` project, under the `Program.cs` file, add the following code `builder.Services.AddSingleton<{YOUR FILE NAME HERE}>();`.
3. In the `Desktop` project, under the `MauiProgram.cs` file, add the following code `builder.Services.AddSingleton<{YOUR FILE NAME HERE}>();`.
4. Use `@Inject {YOUR FILE NAME HERE} {VARIABLENAME}` at the top of any your pages to utilize your singleton.

## Scoped Resources
A Scoped dependency is similar to a Singleton dependency in so far as Blazor will inject the same instance into every object that depends upon it, however, the difference is that a Scoped instance is not shared by all users. To implement this it is basically the same as the singleton, but it requires an Interface and a Class.
1. Create a new interface in the `Base` project under the IServices or IRepositories folder
2. Create a new class that implements the interface in the `Base` project under the Services or Repositories folder
3. In the `Web` project, under the `Program.cs` file, add the following code `builder.Services.AddScoped<{YOUR INTERFACE FILE NAME HERE},{YOUR CLASS FILE NAME HERE}>();`.
4. In the `Desktop` project, under the `MauiProgram.cs` file, add the following code `builder.Services.AddScoped<{YOUR INTERFACE FILE NAME HERE},{YOUR CLASS FILE NAME HERE}>();`.
5. Use `@Inject {YOUR INTERFACE FILE NAME HERE} {VARIABLENAME}` at the top of any your pages to utilize your scroped resource.

## Shared WWWRoot Directory
Instead of copying your WWWRoot directory accross all three projects, just put all your central files in the `Base` project, but for CSS and JS you still need to reference them in the `App.razor` file like this:
> `<link rel="stylesheet" href="_content/Base/{PATH TO YOUR FILE HERE}" />`

And in the `Desktop` project in the	`index.html` file like so:
> `<link rel="stylesheet" href="_content/Base/{PATH TO YOUR FILE HERE}" />`

## Nuget Packages
You can install as needed nuget packages to `Base` and they will carry over to the other projects. They will need to be installed per project if you plan to write code using them in the other two, but you can excute what you need to from `Base`.

### Blazored Resources
Blazored Modal and Toast are included in the project to showcase how to effectively add them and utilize them across the projects. In `Base` modals folders is where you can store all your custom modals.

## Lazy Loading RCL
A crazy addition is the ability to lazy load or load at runtime Razor components. This allows you to create custom components and load when and where you need them. You can just call the component or pass parameters. Refer to the Lazy page to see how to implement this.

## Included Addons Libraries
#### CSS
- Bootstrap
- Font Awesome

#### Nuget
- Blazored Modal
- Blazored Toast
- Dapper
- MySqlConnector
- System.Data.SqlClient