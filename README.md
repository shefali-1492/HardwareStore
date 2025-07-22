# Full Stack Web Application

This is a full stack web application consisting of:

- **Backend**: ASP.NET Core Web API using .NET 8
- **Frontend**: React.js v19 with TypeScript

---

## Technologies Used

### Backend

- ASP.NET Core Web API
- .NET 8
- Minimal APIs (or Controllers - depending on your structure)
- Entity Framework Core (if using a database)
- MediatR (optional for CQRS)
- SQL Server or other DB (optional)

### Frontend

- React.js v19
- TypeScript
- Axios (for API calls)
- React Router v6+
- Vite or Create React App (as base setup)

---

## Project Structure

```
/backend     -> ASP.NET Core Web API (.NET 8)
/frontend    -> React.js v19 application
```

---

## Getting Started

### Backend Setup

```bash
cd backend
dotnet restore
dotnet build
dotnet run
```

- The API should run on `https://localhost:5001` or a similar port.

### Frontend Setup

```bash
cd frontend
npm install
npm start      # or: npm run dev (if using Vite)
```

- The React app will run on `http://localhost:3000` (or `5173` with Vite).

---

## API Integration

The frontend makes HTTP requests to the backend via Axios or Fetch. Update the base URL in `.env` or API service files accordingly.

---

## Development Tips

- Use `CORS` in backend to allow frontend calls.
- Ensure matching ports and base URLs in environment configs.
- Use Docker for containerized development if needed.

---

## License

This project is open-source and available under the MIT License.
