# Tableau Interface

here begins commit 4b35ef99

- start with template

```
dotnet new webapp
```
- overwrite files
```
dotnet new react --force
```
- vue cli create  - the `-n` specifies that no git repo should be made
```
vue create vue-client -n
```
move the contents of the newly created vue project to a PascalCase folder
```
mkdir VueClient
cp -a vue-client/. VueClient/
rm -r vue-client
cd Tableau
mkdir -p Data/Models
```
- add context code

- install packages 

```
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.Extensions.Logging.Debug
dotnet add package VueCliMiddleware
```
here begins commit 76142197

- add code taken from scaffolded react web app => [medium article](https://medium.com/software-ateliers/asp-net-core-vue-template-with-custom-configuration-using-cli-3-0-8288e18ae80b)

in startup.cs change

```
spa.UseReactDevelopmentServer(npmScript: "start");
```
to  
```
spa.UseVueCli(npmScript: "serve", port: 8080);
```
and
```
configuration.RootPath = "ClientApp/build";
```
to
```
configuration.RootPath = "../VueClient";
```
and
```
app.UseSpaStaticFiles();
```
to
```
app.UseSpa(spa =>
{
    spa.Options.SourcePath = "../VueClient";

    if (env.IsDevelopment())
    {
        spa.UseVueCli(npmScript: "serve", port: 8080);
    }
});
```
add
```
services.AddRazorPages();
```


in tableau.csproj change
```
<SpaRoot>ClientApp\</SpaRoot>
```
```
<SpaRoot>$(ProjectDir)..\VueClient\</SpaRoot>
```
and
```
<DistFiles Include="$(SpaRoot)build\**" />
```
to
```
<DistFiles Include="$(SpaRoot)dist\**" />
```
here begins commit a62b90ee
- add vue.config.js and code for https only 

- Settings used:
  - Id
  - Title
  - Type
  - Url
  - Workbook
  - Tabs
  - Description
  - DetailDescription
  - Thumbnail
  - Settings

- if ever get a weird dotnet error about http proxy can try
```
dotnet watch run
```
here starts commit a9f2e035

- add dbcontext code

- add sqlite code to startup.cs for dev will change later to sql server


```
services.AddDbContext<SchoolContext>(options =>
  options.UseSqlite(Configuration.GetConnectionString("TableauContext")));
```
- add connection string to appsettings.json
```
"ConnectionStrings": {
  "TableauContext": "Data Source=TableauDb.db"
}
```
here begins commit 2d4d0e52 

- make a json file containing your settings to populate the dashboard
  - if you have access to PAVE database settings for current dashboards you can scaffold some of the data by using console.log in your browser.
    - right click output data and save as temp variable
    - use the JSON library to evaluate the lazy loaded data
    ```
    copy(JSON.parse(JSON.stringify(temp0)))
    ```
    - and now the expanded variable is in your clipboard
- add models
  - dashboards
      - foriegn key reference to settings by icollection = new list
      - method in class to de/serialize json
  - settings 

here begins commit 0f6b146c 


- add controller for dashboards
  - get using json serialization for now from file 
  - eventually will scaffold CRUD operations from db

- add db initialization code in program.cs

- before continuing with dbinit setup this is a good time to see if the empty sqlite db is created correctly

- add dbinit code
  - when adding the settings no need to keep track/add it's id bec EF does it automatically; otherwise throws error.

- scaffold dashboard pages

here begins commit a5a40306 

- add db init logic to extract from seed json
    - when adding the settings no need to keep track/add it's id bec EF does it automatically; otherwise throws error.
    - changed Guid to id for simplicity
    - temporarily commented out spa code so load is quicker for debug

here begins commit 53821caa 

- scaffold dashboard pages

```
dotnet aspnet-codegenerator razorpage -m Dashboard -dc Tableau.Data.TableauContext -udl -outDir Pages\\Tableaux --referenceScriptLibraries
or
dotnet aspnet-codegenerator razorpage -m Dashboard -dc Tableau.Data.TableauContext -udl -outDir Pages/Tableaux --referenceScriptLibraries
```

- added razor pages
  - this needs to be added to startup.cs which is the crucial part that was overwritten when adding react template
```
app.UseEndpoints(endpoints =>
{
  endpoints.MapRazorPages();

  endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

});
```
- scaffold settings pages

```
dotnet aspnet-codegenerator razorpage -m Setting -dc Tableau.Data.TableauContext -udl -outDir Pages\\Settings --referenceScriptLibraries
or
dotnet aspnet-codegenerator razorpage -m Setting -dc Tableau.Data.TableauContext -udl -outDir Pages/Settings --referenceScriptLibraries
```


here begins commit 478a81e
- add basic styling and networking libs
```
npm install --save vue bootstrap-vue bootstrap axios vue-cookies
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'

// Install BootstrapVue
Vue.use(BootstrapVue)
// Optionally install the BootstrapVue icon components plugin
Vue.use(IconsPlugin)

import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
```
here begins commit 15d846b and 4e5c156

- add api viewer to vue client
  - uses basic table component to display api data
    - added fields parser to a b-table wrapper

- modularized store
- files for objects with string constants for api endpoints and mutations

commit 5564d2c and 4ca2ba9 (in between and after the previously mentioned two)
- add cors 
- add sqlite
- add razor 
- add mvc (both razor and mvc would have happened earlier but i bootstrapped that in the wrong order so added in this commit)

```
services.AddCors(options =>
{
  // this defines a CORS policy called "default"
  options.AddPolicy("default", policy =>
  {
    policy.AllowAnyOrigin()
      .AllowAnyHeader()
      .AllowAnyMethod();
  });
});

...

app.UseCors("default");

```

commit afde8c3d
- removed cookie code that got copied over from other project with modular store template
- TODO consider adding some cookie functionality - will prob be necessary for auth

Commit 06c67cd2 

- started adding routes
  - in this commit i define the paths in a redundant way which later get simplified
- added consts to api call

Commit d253dafb

- commit ends with Nav displaying nested options correctly
```
<b-nav>
    <b-nav-item-dropdown
      v-for="(typedTableaux, type, i) in getTableauxByType"
      :key="i"
      :to="'/tableaux/' + type"
      :text="getTableauxTypes[i]"
    >
      <b-dropdown-item
        v-for="(tableau, i) in typedTableaux"
        :key="i"
        :class="{disabled: tableau.disabled === 'true' ? true : false}"
        :to="'/' + type + '/' + tableau.workbook"
      >
        {{tableau.title}}
      </b-dropdown-item>
    </b-nav-item-dropdown>
  </b-nav>
```
  - nested for loops renders each dashboard by 'type'
  - route definitions will change in later commits so they actually work
  - getTableauxTypes, getTableauxByType, and parseSettings functions in store are used to categorize the data from api call, and flatten the nested settings

Commit fa077307

- made modifications to make a clearer root/entry point structure 

Commit 26413995

- added split to nav buttons to maintain click functionality instead of hover as [intended](// https://webdesign.tutsplus.com/tutorials/how-to-make-the-bootstrap-navbar-dropdown-work-on-hover--cms-33840
) by bootstrap designer.
  - That link is to a tutorial that references it but shows you how to do it anyway.  I ended up finding this split button instead which seemd like a good option.
  - got a nice transition effect for the toggle from it

Commit 68a56c98

- this commit begins to see the routes load dynamically
- also added a different recase method for the other kind of header (modified slightly later)

Commit edd7b98f 

- finally showing a different header depending on the component used
  - crucially changing the ways the routes are declared in the links in nav
- improved on calculated field for header since it's all in one component now

Commit ee791e84

- building on that last idea, added v-if to only load the tableau thumbs or component if it is not the root component so it doesn't try to compute something unavailable

Commit 974ac974

- building tableau server url
  - tableau url is combination of a [base url] + [workbook name] + [tab name]
  - the share button on a dashboard has this info plus some extra parameters that are not needed to access the correct target

- for now the tabs and tableau types are calculated in one component which gets split up in a later commit

Commit 62ad5260

- added thumbnail image files
  - TODO future get thumbnail resources from tableau server API

- move thumbs to thumbnail component 

- also cleaned up some of the metadata v-for stuff i used for early dev

Commit 76068221

- moved image files to within src
  - not sure if this was necessary bec i eventually figured out
- used require('image.png') syntax as per bootstrap-vue docs
  - enable relative urls for bootstrap-vue https://bootstrap-vue.js.org/docs/reference/images/#using-require-to-resolve-image-paths


Commit 55fd1a32

Commit 35a79f9f

- styling
  - thumbnail component relative sizing
  - fixed grid layout

Commit 03b1c62b

- moved tabs computed property to lowest level child element so it reacts consistently

Commit a2aa12fe

- thumbnails all work an display sort of neatly
  - TODO calculate number of columns depending on content

- add PCF steeltoe libs
```
dotnet add package Steeltoe.Discovery.ClientCore
dotnet add package Steeltoe.Extensions.Configuration.CloudFoundryCore
dotnet add package Steeltoe.Security.Authentication.CloudFoundryCore
dotnet add package Steeltoe.Common.Hosting
```

- add solution file
```
dotnet new sln
dotnet sln tableau-interface.sln add Tableau/Tableau.csproj
```

- scaffold Views
  - https://gavilan.blog/2018/04/28/asp-net-core-2-doing-scaffolding-with-dotnet-cli-aspnet-codegenerator/
  - https://stackoverflow.com/questions/41011700/how-to-generate-controller-using-dotnetcore-command-line
```
dotnet aspnet-codegenerator view Headers Empty -outDir Views/Headers -udl
```
TODO

- add [related data](https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/read-related-data?view=aspnetcore-3.1&tabs=visual-studio) code to razor pages 
