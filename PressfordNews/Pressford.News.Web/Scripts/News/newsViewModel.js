var articleApiUrl = '/api/Article/';
var commentApiUrl = '/api/Comment/';
var likeApiUrl = '/api/Like/';


// Models
function Article(data) {
    var self = this;
    data = data || {};
    self.ArticleId = data.ArticleId;
    self.Title = ko.observable(data.Title || "");
    self.Content = ko.observable(data.Content || "");
    self.Author = data.Author || "";
    self.ArticleDate = data.ArticleDate;
    self.error = ko.observable();
    self.Comments = ko.observableArray();
    self.NumberOfLikes = ko.observable(data.NumberOfLikes);
    self.NumberOfComments = ko.observable(data.NumberOfComments);

    self.newCommentMessage = ko.observable();
    self.addComment = function () {
        var comment = new Comment();
        comment.ArticleId = self.ArticleId;
        comment.Message(self.newCommentMessage());
        return $.ajax({
            url: commentApiUrl + "Add",
            dataType: "json",
            contentType: "application/json",
            cache: false,
            type: 'POST',
            data: ko.toJSON(comment)
        })
       .done(function (result) {
           self.Comments.push(new Comment(result));
           self.newCommentMessage('');
       })
       .fail(function () {
           error('unable to add article');
       });


    }

    if (data.Comments) {
        var mappedComments = $.map(data.Comments, function (item) { return new Comment(item); });
        self.Comments(mappedComments);
    }
    self.toggleComment = function (item, event) {
        $(event.target).next().find('.publishComment').toggle();
    }
}

function Comment(data) {
    var self = this;
    data = data || {};

    // Persisted properties
    self.CommentId = data.CommentId;
    self.ArticleId = data.ArticleId;
    self.Message = ko.observable(data.Message || "");
    self.CommentedBy = data.CommentedBy || "";
    self.CommentedDate = data.CommentedDate;
    self.error = ko.observable();
    //persist edits to real values on accept
    self.deleteComment = function () {
    }
}

function newsViewModel() {
    var self = this;
    self.articles = ko.observableArray([]);
    self.newArticle = ko.observable();
    self.mostLikedArticle = ko.observable();
    self.error = ko.observable();
    self.loadArticles = function () {
        //To load existing articles
        $.ajax({
            url: articleApiUrl+"Get",
            dataType: "json",
            contentType: "application/json",
            cache: false,
            type: 'GET'
        })
            .done(function (data) {
                if (data.Articles.length > 0) {
                    $.each(data.Articles, function(index,article)   
                    {
                        self.articles.push(new Article(article));

                    });

                }
            })
            .fail(function () {
               self.error('unable to load posts');
            });
    }

    self.addArticle = function () {
        var article = new Article();
        article.Content(self.newArticle());
        return $.ajax({
            url: articleApiUrl,
            dataType: "json",
            contentType: "application/json",
            cache: false,
            type: 'POST',
            data: ko.toJSON(article)
        })
       .done(function (result) {
           self.articles.splice(0, 0, new Article(result));
           self.newArticle('');
       })
       .fail(function () {
          self.error('unable to add post');
       });
    }
    self.loadArticles();
    return self;
};

//custom bindings

//textarea autosize
ko.bindingHandlers.jqAutoresize = {
    init: function (element, valueAccessor, aBA, vm) {
        if (!$(element).hasClass('msgTextArea')) {
            $(element).css('height', '1em');
        }
        $(element).autosize();
    }
};

ko.applyBindings(new newsViewModel());

