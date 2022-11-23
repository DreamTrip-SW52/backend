Feature: Register clients
As a client
I want to register in the app        
    
    @register-traveler
     Scenario: Register traveler
        Given the Endpoint https://localhost:7160/api/v1/travelers is available
        When a Register traveler request is sent
           | Name        | Lastname        | Email            | Password       | Dni      | Phone     | Photo       |
           | Sample Name | Sample Lastname | sample@email.com | samplepassword | 12345678 | 123456789 | sample link |
        Then a Response is received with Status 200
        And a Traveler Resource is included in Response Body 
           | Id | Name        | Lastname        | Email            | Password       | Dni      | Phone     | Photo       |
           | 1  | Sample Name | Sample Lastname | sample@email.com | samplepassword | 12345678 | 123456789 | sample link |
           
    @register-agency
    Scenario: Register agency
        Given the Endpoint https://localhost:7160/api/v1/agencies is available
        When a Register Agency request is sent
          | Name        | Ruc        | Email            | Password       |
          | Sample Name | ExampleRuc | sample@email.com | samplepassword |
        Then a Response is received with Status 200
        And a Agency Resource is included in Response Body 
          | Id | Name        | Ruc        | Email            | Password       |
          | 1  | Sample Name | ExampleRuc | sample@email.com | samplepassword |