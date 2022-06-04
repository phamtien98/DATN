import './App.css';
import HomePage from './Pages/HomePage/HomePage';
import Sign from './Pages/SignPage/Sign';
import { BrowserRouter, Routes, Route, Link } from 'react-router-dom';
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import IconButton from '@mui/material/IconButton';
import Typography from '@mui/material/Typography';
import MenuIcon from '@mui/icons-material/Menu';
import ValidateSignaturePage from './Pages/ValidateSignaturePage/ValidateSignaturePage';
const PATHS = {
  HOME:'/',
  SIGN:'/sign',
  VALIDATE:'/validate',
}
const Routers= [
  {
    path: PATHS.HOME,
    element: <HomePage/>
  },
  {
    path: PATHS.SIGN,
    element: <Sign/>
  },
  {
    path: PATHS.VALIDATE,
    element: <ValidateSignaturePage/>
  },
]
const NavBars = [
  {
    path: PATHS.HOME,
    title:'Home',
  },
  {
    path: PATHS.SIGN,
    title:'Sign',
  },
  {
    path: PATHS.VALIDATE,
    title:'Validate',
  },
]

function App() {

  return (
   <div>
          <div>
        <BrowserRouter>
          <AppBar position="static">
            <Toolbar>
              <IconButton
                size="large"
                edge="start"
                color="inherit"
                aria-label="menu"
                sx={{ mr: 2 }}
              >
                <MenuIcon />
              </IconButton>
              {NavBars.map(item => (
                <Link to={item.path}>
                  <Typography className="link-title" variant="body1" component="div" sx={{ flexGrow: 1 }}>
                    {item.title}
                  </Typography>
                </Link>
              ))}
            </Toolbar>
          </AppBar>
          <Routes>
            {Routers.map((route) => (
              <Route path={route.path} element={route.element}></Route>
            ))}
          </Routes>
        </BrowserRouter>
      </div>
   </div>
  );
}

export default App;
