# Uniconta API Training
This repository contains various training material for the Uniconta API.

## standalone:
  ### case1: uniconta login skærm
    Task: create connectivity
    Task: verify login

  ### case2: uniconta API wrapper
    Task: create a wrapper class for the uniconta API with the following methods:
      init method
      login/logout method
      InitializeCompany to select default company for the user or first company and check wether the user has access to a company
      get CrudAPI method, to create a new crudAPI.

  ### case3: Data population
    Task: Create a button to populate Uniconta with some data. E.g. Items, Debtors or Orders.
    
  ### case4: Userdefined fields and tables
    Task: Create button to create table(tableheader)
    Task: Create button to populate the table with fields

## IPluginBase:
  ### case5: uniconta indlæsningsværktøj med valg af fil
    Task: get lines from file
    Task: Create Uniconta entities

## IContentbase:
  ### case6: Antal solgt af en item
    Task: Create GUI with overview of items
    Task: Calculate the number of times an item has been solda

## PageEventsBase:
  ### Case7: inventory gem gamle entiteter når en bliver opdateret
    Task: Save old versions of items(with new text) when properties are changed
