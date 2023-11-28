# Domain Models

## Menu

```csharp
class Menu
{
    Menu Create();
    void AddDinner(Dinner dinner);
    void RemoveDinner(Dinner dinner);
    void UpdateSection(MenuSection section);
}
```

```json
{
    "id":"0000-0000",
    "name":"menu name",
    "description":"description",
    "averageRating":4.5,
    "items":[
        {
            "id":"0000-0000",
            "name":"pickles",
            "description":"fried pickles",
            "price":5.99
        }
    ],
    "hostId":"0000-0000",
    "createdDateTime":"",
    "updatedDateTime":"",
    "dinnerIds":[
        "0000-0000",
        "0000-0000"
    ],
    "menuReviewIds":[
        "0000"
    ]
}
```