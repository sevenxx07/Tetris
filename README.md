# MVVM model
The Model-View-ViewModel (MVVM) pattern is a design pattern used in software development, particularly for creating user interfaces. It helps in organizing and structuring code, making it easier to manage, test, and maintain.<br />
Key Components:<br />

* Model:
  - Represents the data and the business logic of the application.
  - It's independent of the user interface and focuses on the core functionality and data of the application.

* View:
  - The visual layer, or the UI, that the user interacts with.
  - It displays data from the Model and sends user inputs to the ViewModel.

* ViewModel:
  - Acts as an intermediary between the Model and the View.
  - It retrieves data from the Model and prepares it for display in the View.
  - It also handles user input from the View, updating the Model as necessary.<br />

How MVVM Works:<br />
The View is bound to the ViewModel. This binding allows the View to automatically reflect changes made in the ViewModel.
The ViewModel fetches data from the Model, processes it if needed, and then exposes it to the View.
The Model remains unaware of the View and ViewModel, which keeps the business logic separate from the UI logic.
The View handles visual representation, while the ViewModel handles the logic that drives the interface.


# Game
![obrazek](https://github.com/user-attachments/assets/1688fd6b-9564-457f-981b-c3000257e5dd)
