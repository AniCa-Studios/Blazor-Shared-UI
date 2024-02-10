# Blazor-Shared-UI
A shared UI between Blazor Web and Hybrid which is not just components but full web pages and other functionality

This is a template project with some example pages to help get you started on your next hybrid Blazor Web and Application Project. This is designed to use both frameworks at the same time pulling from one source, that does mean you will have to modify the base `Web` and `Deskto`p projects to be aware of certain files in the `Base` project.

## Pages
These are the core of what this app is meant for. Giving you the ability to share pages across the two apps. Simply add a new page in the `Base` project under the pages folder. Make sure you includes the `@pages` at the top of the .razor file and it should work right away in this template project.

## Singletons
Singletons restricts the instantiation of a class to a singular instance. If you want to create more singletons to keep track of global variables or states, I have created the examples `Names` to showcase how you would do so. 
1. Create a new class in the `Base` project under the Singleton folder
2. In the `Web` project, under the `Program.cs` file, add the following code `builder.Services.AddSingleton<{YOUR FILE NAME HERE}>();`.
3. In the `Desktop` project, under the `MauiProgram.cs` file, add the following code `builder.Services.AddSingleton<{YOUR FILE NAME HERE}>();`.
4. Use `@Inject {YOUR FILE NAME HERE} {VARIABLENAME}` at the top of any your pages to utilize your singleton.

## Shared WWWRoot Directory
Instead of copying your WWWRoot directory accross all three projects, just put all your central files in the `Base` project, but for CSS and JS you still need to reference them in the `App.razor` file like this:
> `<link rel="stylesheet" href="_content/Base/{PATH TO YOUR FILE HERE}" />`
And in the `Desktop` project in the	`index.html` file like so:
> `<link rel="stylesheet" href="_content/Base/{PATH TO YOUR FILE HERE}" />`