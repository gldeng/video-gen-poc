
# Video Generation Clients and Examples

This repository contains example projects for interacting with various AI APIs:
- **MinimaxExample**: Demonstrates how to use the MiniMax API for AI capabilities
- **KilingAIExample**: Demonstrates how to use the KilingAI API

## Prerequisites

- .NET 8.0 SDK or later
- API keys for the respective services
- Git (for cloning the repository)

## Setup

### 1. Clone the repository

```
git clone [repository-url]
cd [repository-directory]
```

### 2. Set up environment variables

#### For MinimaxExample:

You need to set up the following environment variables:

- `MINIMAX_API_KEY`: Your MiniMax API key
- `MINIMAX_GROUP_ID`: Your MiniMax Group ID

##### Windows:
```
setx MINIMAX_API_KEY "your-api-key"
setx MINIMAX_GROUP_ID "your-group-id"
```

##### macOS/Linux:
```
export MINIMAX_API_KEY="your-api-key"
export MINIMAX_GROUP_ID="your-group-id"
```

#### For KilingAIExample:

You need to set up the following environment variables:

- `KLING_ACCESS_KEY`: Your KilingAI Access Key
- `KLING_SECRET_KEY`: Your KilingAI Secret Key

##### Windows:
```
setx KLING_ACCESS_KEY "your-access-key"
setx KLING_SECRET_KEY "your-secret-key"
```

##### macOS/Linux:
```
export KLING_ACCESS_KEY="your-access-key"
export KLING_SECRET_KEY="your-secret-key"
```

### 3. Restore dependencies

```
dotnet restore
```

## Running the examples

### Running MinimaxExample

```
cd MinimaxExample
dotnet run
```


### Running KilingAIExample

```
cd KilingAIExample
dotnet run
```

## Further Documentation

- [MiniMax API Documentation](https://www.minimax.io/platform/document/platform%20introduction?key=66701c8e1d57f38758d58198)
- [KilingAI Documentation](https://docs.qingque.cn/d/home/eZQAmVjsdCh45-NZ2-_XyYRmG?identityId=2GKuo2cEM8x)
