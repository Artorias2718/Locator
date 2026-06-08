import { useEffect, useState } from 'react'
import './App.css'
import { Route, Routes } from 'react-router-dom';
import Profile from './pages/profile';
import {QueryClientProvider, useQueryClient} from "@tanstack/react-query";
import reactQueryClient from "./api/ReactQueryClient.ts";

function App() {
  return (
    <>
        <QueryClientProvider client={reactQueryClient}>
            <Routes>
                <Route path='/profile' element={<Profile />} />
            </Routes>
        </QueryClientProvider>
    </>
  )
}

export default App
