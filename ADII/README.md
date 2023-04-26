## ADII - Auto Dependency Injection By Interface
This project provides interfaces and functionality to inject dependencies and manage service life cycles through interface declarations.

The goal is to allow straight forward inclusion of new dependencies into a project without the need for a centralised dependency management class which often attracts conflicts in a busy collaborative project.

The main components of the library are a scanner, which scans the project files for the IInjectables<T> and automatically adds them to the dependency container. 
The type <T> that is included allows for the selection of the dependencies life cycle all without leaving the file. This in turn helps limit the scope of file changes to local folders and following a VSA 
approach will further reduce the need to spread code changes beyond the scopes of the feature folder.