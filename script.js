// JavaScript source code
const CreateTodo = async (req, res) => {
    try {
        const todo = await Todo.create(req.body);
        response.Success(res, 'Todo created successfully', todo);
    } catch (err) {
        response.InternalServerError(res, err.message);
    }
};
const GetAllTodos = async (req, res) => {
    try {
        const todos = await Todo.findAll();
        response.Success(res, 'Todos retrieved successfully', todos);
    } catch (err) {
        response.InternalServerError(res, err.message);
    }
};

const GetOneTodo = async (req, res) => {
    try {
        const todo = await Todo.findByPk(req.params.id);
        if (!todo) return response.NotFound(res, 'Todo not found');
        response.Success(res, 'Todo retrieved successfully', todo);
    } catch (err) {
        response.InternalServerError(res, err.message);
    }
};
const UpdateOneTodoById = async (req, res) => {
    try {
        const todo = await Todo.findByPk(req.params.id);
        if (!todo) return response.NotFound(res, 'Todo not found');
        await todo.update(req.body);
        response.Success(res, 'Todo updated successfully', todo);
    } catch (err) {
        response.InternalServerError(res, err.message);
    }
};
const DeleteOneTodoById = async (req, res) => {
    try {
        const todo = await Todo.findByPk(req.params.id);
        if (!todo) return response.NotFound(res, 'Todo not found');
        await todo.destroy();
        response.Success(res, 'Todo deleted successfully');
    } catch (err) {
        response.InternalServerError(res, err.message);
    }
};
