# Htmx, Tailwind, Razor Components, and minimal apis.

The main goal here is to try out [Htmx](https://htmx.org/) within asp.net core using razor components as the template engine.

Htmx has the main concept of partially reloading content while allowing any html element to make http calls.
So can we create a modern looking, spa feeling web app while using server side rendering?

## Getting started

- Install node lts

  ```
  nvm install lts
  nvm use lts
  ```

- Installing dotnet if needed
  - https://learn.microsoft.com/en-us/dotnet/core/install/linux-scripted-manual#scripted-install
    ```
    wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
    chmod +x ./dotnet-install.sh
    ./dotnet-install.sh
    ```

## Runing locally

Debugging the project will run npm install, npm run tailwind:build, as well as start the dotnet dev server.

Build steps are defined in HtmxRazorComponents.csproj

When developing components, in a new terminal window run `npm run tailwind:watch` for the css to be compile/generated as the files are updated.
