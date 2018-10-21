import React, {Component} from 'react';
import styled from 'styled-components';
import {FormContainer, Input, Button} from './consts/styles';
import apiFileCounter from '../api/apiFileCounter';

const FileCounterContainer = styled.div`
    width: 400px;
    margin-bottom: 100px;
    text-align: center;
    user-select: none;
    
    @media screen and (max-width: 500px) {
        width: 300px;
    }
`;

class FileCounter extends Component {
    constructor(props) {
        super(props);
        this.retrieveXmlFileCountInDirectory = this.retrieveXmlFileCountInDirectory.bind(this);
        this.selectDirectoryHandler = this.selectDirectoryHandler.bind(this);
        this.submitDirectoryHandler = this.submitDirectoryHandler.bind(this);

        this.state = {
            result: 0,
            directory: ""
        };
    }

    selectDirectoryHandler = (event) => {
        event.preventDefault();
        this.setState({directory: event.target.value});
    };

    submitDirectoryHandler = (event) => {
        event.preventDefault();
        const directory = {
            directory: this.state.directory
        };
        this.retrieveXmlFileCountInDirectory(directory);
    };

    retrieveXmlFileCountInDirectory = (dir) => {
        try {
            apiFileCounter.countXmlFiles(dir).then(response => {
                const data = response.data;
                this.setState({result: data});
            });
        } catch (e) {
            console.log('Failed to count XML files: ', e);
        }
    };

    render() {
        const {result} = this.state;
        return (
            <FileCounterContainer>
                <FormContainer>
                    <Input type="text" name="counter" placeholder="Select a directory"
                           onChange={this.selectDirectoryHandler}/>
                    <Button onClick={(event) => this.submitDirectoryHandler(event)}>Submit</Button>
                </FormContainer>
                No. of XML files in directory: {result}
            </FileCounterContainer>
        );
    }
}

export default FileCounter;