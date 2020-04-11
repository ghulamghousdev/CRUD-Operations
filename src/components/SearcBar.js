import React from 'react';
import { Paper, TextField} from '@material-ui/core'
class SearchBar extends React.Component {
    state = {
        searchTerm: '',
    }

    toHandleChange = (event) => this.setState({
        searchTerm: event.target.value
    });

    toHandleSubmit = () =>  {
        const { searchTerm } = this.state;
        const { onFormSubmit } = this.props;
        onFormSubmit(searchTerm);
        
    }
    render() {
        return ( 
            <Paper elevation={6}>
                <form onSubmit={this.toHandleSubmit}>
                    <TextField fullWidth label='Search...' onChange={this.toHandleChange}  ></TextField>
                </form>
            </Paper>
        )
    }
}

export default SearchBar;  