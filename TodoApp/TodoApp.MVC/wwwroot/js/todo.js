const showTodos = (filter) => {
    let url = "https://localhost:7212/todo/"
    switch (filter) {
        case 'All':
            url += "getTodos"
            break
        case 'Active':
            url += "getActiveTodos"
            break
        case 'Completed':
            url += "getCompletedTodos"
            break
        default:
            url += "getTodos"
    }
    setTimeout(() => {
        fetch(url)
            .then(response => response.json())
            .then(data => {
                console.log(data)
                let html = ``
                for (let todo of data) {
                    html += getListItemAsString(todo)
                }
                let ul = document.getElementById('todoList')
                ul.innerHTML = html
            })
        changeItemCounter()
    }, 100)
}
showTodos()
const changeItemCounter = () => {
    let childrenCount = document.getElementById('todoList').children.length
    let itemCounter = document.getElementById('itemCounter')
    itemCounter.innerText = `${childrenCount} item${childrenCount > 1 ? 's' : ''} left`
}
const getListItemAsString = (todo) => {
    return `
            <li id="${todo.id}" class="list-group-item fs-5 d-flex justify-content-between align-items-center ${todo.isCompleted ? 'checked' : ''}"
                onclick="toggleCheck('${todo.id}')">
                <div class="me-auto">
                    <span class="check-mark badge text-light me-2">${todo.isCompleted ? '\u2713' : '&nbsp;&nbsp;&nbsp;'}</span>
                    ${todo.name}
                </div>
                <button class="close btn badge text-danger float-end" onclick="removeTodo(event)">&#x2715</button>
            </li>
    `
}
function changeActiveButton(event) {
    let buttons = document.querySelectorAll('.btn-group .btn')
    for (let button of buttons) {
        button.classList.remove('active')
    }
    if (event) {
        event.target.classList.add('active')
        showTodos(event.target.innerText)
    }
    else {
        buttons[0].classList.add('active')
        showTodos()
    }
  
}
const toggleCheck = (todoId) => {
    let data = {
        todoId
    }
    fetch("https://localhost:7212/todo/toggleComplete", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(data)
    })
        .then(res => res.json())
        .then(data => {
            console.log(data)
        })
    showTodos()
}

const addTodo = () => {
    let element = document.getElementById("todo")
    let formData = {
        Name: element.value
    }
    fetch("https://localhost:7212/todo/createTodo", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(formData)
    })
        .then(res => res.json())
        .then(data => {
            console.log(data)
        })
    element.value = ''
    changeActiveButton()
    showTodos()
}
const removeTodo = (event) => {
    event.cancelBubble = true
    let todoId = event.target.parentNode.id
    let data = {
        todoId
    }
    fetch("https://localhost:7212/todo/deteleTodo", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(data)
    })
        .then(res => res.json())
        .then(data => {
            showTodos(data.currentState)

        })
}
const clearAll = () => {
    fetch("https://localhost:7212/todo/deteleAllTodos", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        }
    })
        .then(res => res.json())
        .then(data => {
            showTodos(data.currentState)
        })
    document.getElementById('todoList').innerHTML = ''
    changeItemCounter()
}