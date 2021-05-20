import {createStore} from 'redux';
// import ReactDOM from 'react-dom';
// import './index.css';
// import App from './components/app';
// import reportWebVitals from './reportWebVitals';

// ReactDOM.render(
//   <React.StrictMode>
//     <App />
//   </React.StrictMode>,
//   document.getElementById('root')
// );


// reportWebVitals();
const reducer = (state = 0, action: any) => {
  switch (action.type) {
    case "INC":
      return state + 1;
    default:
      return state;
  }
}
const store = createStore(reducer);
store.subscribe(() => console.log(store.getState()));
store.dispatch({type: "INC"})
store.dispatch({type: "INC"})
store.dispatch({type: "INC"})
store.dispatch({type: "INC"})





