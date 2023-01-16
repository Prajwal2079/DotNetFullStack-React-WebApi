import { useEffect, useState } from "react"
import axios from "axios";

const DisplayData = () => {
   let [userList, setUserList] = useState([]);

   useEffect(() => {
      axios.get("http://localhost:5001/user")
         .then((response) => {
            setUserList(response.data)
         })
   }, []);

   const displayUserList = () => {
      return userList.map((user) => {
         return (
            <tr>
               <td>{user.userid}</td>
               <td>{user.username}</td>
               <td>{user.course}</td>
            </tr>
         )
      })
   }

   return (
      <div>
         <table>
            <thead>
               <tr>
                  <th>UserID</th>
                  <th>UserName</th>
                  <th>Course</th>
               </tr>
            </thead>
            <tbody>
               {displayUserList()}
            </tbody>
         </table>
      </div>
   )
}

export default DisplayData;