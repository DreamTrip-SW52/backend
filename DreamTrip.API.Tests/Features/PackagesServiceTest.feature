Feature: View or Create Package
    As traveler I want to view a travel package
    As a travel agency I want to create a travel package
    
    Background: 
        Given the Endpoint https://localhost:7160/api/v1/package is available
        
    @view-package
    Scenario: View Package (Traveler)
        When a Get request is sent with id 1
        Then a Response Package with Status 200
        And a Package Resource is included in Response Body
            | Id | Name   | Description | LocationAddress | Duration | Capacity | Price | Image  | AgencyId | LocationId | Views | Sales | Category |
            | 1  | Sample | Sample      | Sample          | 3        | 13       | 100   | Sample | 1        | 1          | 1     | 1     | STANDARD |
    
    @create-package
    Scenario: Create Package (Travel agency)
        When a Post request is sent 
            | Name   | Description | LocationAddress | Duration | Capacity | Price | Image  |  Views | Sales | Category | AgencyId | LocationId |
            | Sample | Sample      | Sample          | 3        | 13       | 100   | Sample |  1     | 1     | STANDARD |1         | 1          |
        Then a Response Package with Status 200
        And a Package Resource is included in Response Body
          | Id | Name   | Description | LocationAddress | Duration | Capacity | Price | Image  | Views | Sales | Category | AgencyId | LocationId |
          | 1  | Sample | Sample      | Sample          | 3        | 13       | 100   | Sample | 1     | 1     | STANDARD | 1        | 1          | 