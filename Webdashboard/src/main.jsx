import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import App from './Components/app'

import './index.css'

ReactDOM.createRoot(document.getElementById('root')).render(
  <BrowserRouter>
  <App/>
</BrowserRouter>,
)
