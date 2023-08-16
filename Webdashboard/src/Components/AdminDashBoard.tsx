import React from 'react';
//import { useNavigate } from 'react-router-dom';



const AdminDashBoard: React.FC = (() => {

    return (
        <div className="">
            <div className=' mt-16 grid grid-rows-12 grid-flow-col gap-4'>
                <div className=' ml-3 col-span-3'>

                </div>
                <div className=' col-span-3  grid grid-rows-3 grid-flow-col gap-4'>

                    <input className=' text-center col-span-6' type="text" placeholder='UID' />
                    <input className=' text-center col-span-6' type="password" placeholder='Password' />
                    <button className=' text-center col-span-6 bg-white  text-black font-bold text-xl '>Create</button>
                </div>

                <div className=' col-span-3'>
                    <div className=' col-span-3  grid grid-rows-3 grid-flow-col gap-4'>

                        <input className=' text-center col-span-6' type="text" placeholder='UID' />

                        <button className=' text-center col-span-6 bg-white  text-black font-bold text-xl '>Delete</button>
                    </div>
                </div>


                <div className=' col-span-3 mr-48'>
                    <div className=' col-span-3  grid grid-rows-3 grid-flow-col gap-4'>

                        <button className=' text-center col-span-6 bg-white  text-black font-bold text-xl  ' >Get list of users</button>
                    </div>
                </div>

            </div>
        </div>


    )
})


export default AdminDashBoard

