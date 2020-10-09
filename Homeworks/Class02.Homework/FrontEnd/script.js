//String elements
//Get all
const allStringsBtn = document.getElementById("get-all-user-strings-btn");
const allStringsContent = document.getElementById("all-strings-content");
//Get by ID
const getStringInput = document.getElementById("user-string-id");
const getStringBtn = document.getElementById("get-string-by-id-btn"); 
const getStringContent = document.getElementById("get-string-by-id-content");
//Post String
const postStringInput = document.getElementById("post-string-input");
const postStringBtn = document.getElementById("post-string-btn");
const postStringContent = document.getElementById("add-username-string-content");
//Delete String
const deleteStringInput = document.getElementById("delete-string-id");
const deleteStringBtn = document.getElementById("delete-string-btn");
const deleteStringContent = document.getElementById("string-delete-content");

//User elements
//Get all users
const allUsersBtn = document.getElementById("get-all-users-btn");
const allUsersContent = document.getElementById("all-users-content");
const allUsersThead = document.getElementById("all-users-thead");
const allUsersTbody = document.getElementById("all-users-tbody");
const allUsersTable = document.getElementById("all-users-table");
var allUsersFlag = false;
//Post User
const UserFirstNameInput = document.getElementById("first-name");
const UserLastNameInput = document.getElementById("last-name");
const UserIdInput = document.getElementById("user-id");
const postUserBtn = document.getElementById("post-user-submit-btn");
const postUserContent = document.getElementById("post-users-content");

const url = "http://localhost:62580/users";

//Get all strings
allStringsBtn.addEventListener("click", () =>
{
    async function getAllStrings(url)
    {
        const result = await fetch(url);
        const data = await result.json();
        console.log(data);

        allStringsContent.innerHTML = 
        `
        <ul>
        `;
        for (let userString of data)
        {
            allStringsContent.innerHTML = allStringsContent.innerHTML+ `<li>${userString}</li>`
        }
        allStringsContent.innerHTML = allStringsContent.innerHTML+"</ul>"

    }
    getAllStrings(url);
})

//Get a string by ID
getStringBtn.addEventListener("click", ()=>
{
    const inputData = getStringInput.value;
    if (inputData === "")
    {
        getStringInput.placeholder = "Please enter a value!"
    }
    else 
    {
        let newUrl = `${url}/${inputData}`;
        console.log(newUrl);
        

        async function getStringByID(url)
        {
            
            
            const result = await fetch(newUrl,
                {
                    headers: 
                    {
                        'Accept': 'application/json'
                        
                    }
                }
                );
            const data =  JSON.parse(result);
            getStringContent.innerHTML = `${result}`;
        }
        getStringByID(url);
    }
});

//Post a string to the list
postStringBtn.addEventListener("click", () =>
{
    let postData = postStringInput.value;

    if (postData === "")
    {
        postStringInput.placeholder = "Please enter a value!"
    }
    else 
    {
        console.log(postData);
        async function PostData(url, data)
        {
            const response = await fetch(url, 
                {
                    method: "POST",
                    mode: "cors",
                    headers: 
                    {
                        'Accept': 'application/json'
                    },
                    body: data
                });
    
            const result = await response.json();
    
            postStringContent.innerHTML = `${result}`;
        }
        PostData(url, postData);
    }

    

});

//Delete a string from the list 
deleteStringBtn.addEventListener("click", () =>
{
    const deleteID = deleteStringInput.value;

    async function DeleteStringByID(url, data)
    {
        const response = await fetch(url, 
        {
            method: "DELETE",
            headers: 
            {
                'Accept': 'application/json'
            },
            body: data
        });
        const result = await response.json();
        deleteStringContent.innerHTML = `${result}`;
    
    }
    DeleteStringByID(url, deleteID);
})


//Get all users
allUsersBtn.addEventListener("click", () =>
{
    let newUrl = `${url}/usermodels`

    async function GetAllUsers(url)
    {
        const response = await fetch(url);
        const result = await response.json();
        console.log(result);

        allUsersThead.innerHTML = 
        `
            <tr>
                <th>First Name</th>
                <th>Last Name</th>
                <th>ID</th>
            </tr>
        `;
        for (let user of result)
        {
            allUsersTbody.innerHTML += 
            `
            <tr>
                <td>${user.firstName}</td>
                <td>${user.lastName}</td>
                <td>${user.id}</td>            
            </tr>
            `
        }

       
        
    }
    if(!allUsersFlag)
    {
        GetAllUsers(newUrl);
        
        allUsersFlag = true;
    }
    else
    {
        allUsersThead.innerHTML = "";
        allUsersTbody.innerHTML = "";
        allUsersFlag = false;
    }
})

//Post a user
postUserBtn.addEventListener("click", () =>
{
    let firstNameData = UserFirstNameInput.value;
    let lastNameData = UserLastNameInput.value;
    let idData = UserIdInput.value;

    if(firstNameData==="" || lastNameData==="" || idData==="")
    {
        if(firstNameData === "")
        {
            UserFirstNameInput.placeholder = "Please enter a value!";
        }
        if (lastNameData === "")
        {
            UserLastNameInput.placeholder = "Please enter a value!";
        }
        if (idData === "")
        {
            UserIdInput.placeholder = "Please enter a value!";
        }
    }
    else
    {
        const data = 
        {
            firstName: firstNameData,
            lastName: lastNameData,
            id: idData
        }
        const JsonData = JSON.stringify(data);

        let newUrl = url+'/usermodels';

        async function PostUser(url, data)
        {
            const response = await fetch(url,
            {
                method: "POST",
                headers:
                {
                    'Accept': 'application/json'
                },
                body: JsonData
            })
            const result = await response.json();
            console.log(response);

            postUserContent.innerHTML = `${result}`;
            
        }
        PostUser(newUrl, data)
    }
})




