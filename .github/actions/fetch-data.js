const { Octokit } = require("@octokit/action");

fetchData();

async function fetchData() {
    const octokit = new Octokit();

    // See https://developer.github.com/v3/issues/comments/#create-a-comment
    const { data } = await octokit.request(
        "GET /repos/:owner/:repo/releases"
    );

    console.log(data);
}

