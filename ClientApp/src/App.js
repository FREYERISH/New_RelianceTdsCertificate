import React from 'react';
import Card from './components/Card/Card';
import Admin from './components/Admin/Admin';
import { createBrowserRouter, RouterProvider, Outlet } from 'react-router-dom';
import AdminUpload from "./components/Admin/AdminUpload";
import AdminDownload from "./components/Admin/AdminDownload";
import User from './components/User/User';
import Header from './components/Header/Header'

const Layout = () => {
    return (
        <div className="app">
            <Header />
            <Outlet />
        </div>
    );
};

const router = createBrowserRouter([
    {
        path: "/",
        element: <Layout />,
        children: [
            {
                path: "/",
                element: <Card />
            },
            {
                path: "/Admin",
                element: <Admin />
            },
            {
                path: "Admin/admin-upload",
                element: <AdminUpload />
            },
            {
                path: "Admin/admin-download",
                element: <AdminDownload />
            },
            {
                path: "/User",
                element: <User />
            }
        ]
    }
]);

function App() {
    return (
        <div>
            <RouterProvider router={router} />
        </div>
    );
}

export default App;



/*
       <BrowserRouter>
       <Routes>
         <Route path='/' Component={Card}></Route>
         <Route path='/Admin' Component={Admin}></Route>
         <Route path="/Admin/admin-upload" Component={AdminUpload} />
         <Route path="/Admin/admin-download" Component={AdminDownload} />
         <Route path="/User" Component={User} />
       </Routes>
       </BrowserRouter>
   */
