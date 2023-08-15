import LoginPage from "./LoginPage";
import AdminDashBoard from "./AdminDashBoard";
import React from 'react';

import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

const App: React.FC = (() => {



    return (
        <div>
            <Routes>
                <Route path="/" element={<LoginPage />} />
                <Route path="/admin" element={<AdminDashBoard />} />

                {/* <Route path="*" element={<NotFound />} /> */}
            </Routes>
        </div>
    );

})
export default App