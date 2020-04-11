import React from 'react'
import { Grid } from '@material-ui/core';

import SearchBar from './components/SearcBar'
import VideoDetails from './components/VideoDetails'

import youtube from './api/youtube';

class App extends React.Component {

    handleSubmit = async(SearchTerm) => {
        const responseFromYoutubeApi = await youtube.get('search', {
            params: {
                part: 'snippet',
                maxResults: 10,
                key: 'AIzaSyBZhe3_TpLrl5jMIpt1lpc'  ,
                q: SearchTerm,
            }
        });

        console.log(responseFromYoutubeApi);
    }
    render() {

        return ( 
                <Grid justify = "center" container spacing = { 10 }>
                    <Grid item xs = { 12 } >
                        <Grid container spacing ={10}>
                            <Grid item xs = { 12 }>
                              <SearchBar onFormSubmit={this.handleSubmit} > </SearchBar>
                            </Grid>
                            <Grid item = { 8 }>
                                 <VideoDetails />
                            </Grid>
                            <Grid item = { 4 }> 
                                { /*video List*/ } 
                            </Grid> 
                        </Grid> 
                    </Grid> 
                </Grid>
        )
    }
}



export default App;